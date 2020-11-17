using System;
using System.IO;
using System.Reflection;
using BDFramework;
using UniRx;
using UnityEngine;

namespace QFramework
{
    public enum ILKitExecuteMode
    {
        /// <summary>
        /// 執行正常的 C# 代碼
        /// </summary>
        Editor,
        Reflection,
        ILRuntime,
    }

    public class ILRuntimeScript : IScript
    {

        
        public ILKitExecuteMode Mode = ILKitExecuteMode.Editor;

        private Assembly Assembly { get; set; }


        // 加載 dll
        // isregisterBindings 為 false 時，是生成 binding的時候
        public void LoadDll(string dllPath, bool isRegisterBindings = true)
        {
            if (Mode == ILKitExecuteMode.ILRuntime)
            {
                ILRuntimeHelper.LoadHotfix(dllPath, isRegisterBindings);
            }
            else if (Mode == ILKitExecuteMode.Reflection)
            {
                var bytes = File.ReadAllBytes(dllPath);
                var bytes2 = File.ReadAllBytes(dllPath + ".mdb");
                Assembly = Assembly.Load(bytes, bytes2);

                Debug.Log(Assembly);
            }
            else if (Mode == ILKitExecuteMode.Editor)
            {
                //PC模式

                //这里用反射是为了 不访问逻辑模块的具体类，防止编译失败
                Assembly = Assembly.GetExecutingAssembly();
            }
        }

        // 加載 dll
        // isregisterBindings 為 false 時，是生成 binding的時候
        public void LoadDll(byte[] bytes)
        {
            Assembly = Assembly.Load(bytes);
        }

        //只在非Editor模式下生效
        public static HotfixCodeRunMode CodeRunMode = HotfixCodeRunMode.ByILRuntime;


        public void CallStaticMethod(string typeOrFileName, string methodName, params object[] args)
        {

            if (Mode == ILKitExecuteMode.ILRuntime)
            {
                ILRuntimeHelper.AppDomain.Invoke(typeOrFileName, methodName, null, args);
            }
            else
            {
                var type = Assembly.GetType(typeOrFileName);
                var method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
                method.Invoke(null, args);
            }
        }

        public void LoadScript(Action loadDone)
        {
            //初始化资源加载
            string dllPath = "";

            //code
            if (ILRuntimeScriptSetting.SimulationMode == AssetLoadPath.SimulationMode)
            {
                Mode = ILKitExecuteMode.Editor;
            }
            else if (ILRuntimeScriptSetting.SimulationMode == AssetLoadPath.StreamingAsset)
            {
                dllPath = ILRuntimeScriptSetting.LoadDLLFromStreammingAssetsPath
                    ? ILRuntimeScriptSetting.DllFileStreamingFullPath
                    : ILRuntimeScriptSetting.DllFilePersistentFullPath;
            }

            if (CodeRunMode == HotfixCodeRunMode.ByReflection)
            {
                Mode = ILKitExecuteMode.Reflection;
            }
            else if (CodeRunMode == HotfixCodeRunMode.ByILRuntime)
            {
                Mode = ILKitExecuteMode.ILRuntime;
            }

            if (dllPath != "")
            {

                //反射
                if (CodeRunMode == HotfixCodeRunMode.ByReflection &&
                    (Application.isEditor || Application.platform == RuntimePlatform.Android ||
                     Application.platform == RuntimePlatform.WindowsPlayer))
                {
                    Mode = ILKitExecuteMode.Reflection;
                    //反射模式只支持Editor PC Android
                    if (File.Exists(dllPath)) //支持File操作 或者存在
                    {
                        LoadDll(dllPath);
                        loadDone.InvokeGracefully();
                    }
                    else
                    {
                        //不支持file操作 或者不存在,继续尝试
                        var path = dllPath;

                        if (Application.isEditor)
                        {
                            path = "file://" + path;
                        }

                        ObservableWWW.GetAndGetBytes(path).Subscribe(bytes =>
                        {
                            LoadDll(bytes);
                            loadDone.InvokeGracefully();

                        }, e => { Debug.LogError("DLL加载失败:" + e); });
                    }
                }
                //ILR
                else
                {
                    //ILRuntime基于文件流，所以不支持file操作的，得拷贝到支持File操作的目录

                    //这里情况比较复杂,Mobile上基本认为Persistent才支持File操作,
                    //可寻址目录也只有 StreamingAsset
                    var firstPath = ILRuntimeScriptSetting.DllFilePersistentFullPath;
                    var secondPath = ILRuntimeScriptSetting.DllFileStreamingFullPath;

                    if (!File.Exists(dllPath)) //仅当指定的路径不存在(或者不支持File操作)时,再进行可寻址
                    {
                        dllPath = firstPath;
                        if (!File.Exists(firstPath))
                        {
                            //验证 可寻址目录2
                            var source = secondPath;
                            var copyto = firstPath;
                            Debug.Log("复制到第一路径:" + source);

                            ObservableWWW.GetAndGetBytes(source)
                                .Subscribe(bytes =>
                                {
                                    copyto.CreateDirIfNotExists4FilePath();
                                    File.WriteAllBytes(copyto, bytes);

                                    //解释执行模式
                                    Mode = ILKitExecuteMode.ILRuntime;
                                    LoadDll(copyto);
                                    loadDone.InvokeGracefully();

                                }, e => { Debug.LogError("可寻址目录不包括DLL:" + source); });
                            return;
                        }
                    }

                    //解释执行模式
                    Mode = ILKitExecuteMode.ILRuntime;
                    LoadDll(dllPath);
                    loadDone.InvokeGracefully();
                }
            }
            else
            {
                // pc 模式
                Mode = ILKitExecuteMode.Editor;
                LoadDll("");
                loadDone.InvokeGracefully();
            }
        }

        public void Dispose()
        {
            ILRuntimeHelper.Close();
        }
    }
}