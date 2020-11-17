using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using BDFramework;
using ILRuntime.Runtime.CLRBinding;
using QFramework.PackageKit;
using Tool;
using UniRx;
using UnityEditor;
using UnityEngine;

namespace QFramework
{
    [DisplayName("ScriptKit ILRuntime 设置")]
    [PackageKitRenderOrder(4)]
    public class ScriptKitILRuntimeEditorView : IPackageKitView
    {
        public IQFrameworkContainer Container   { get; set; }
        public int                  RenderOrder { get; }
        public bool                 Ignore      { get; }

        public bool Enabled
        {
            get { return true; }
        }

        private VerticalLayout mRootLayout = null;


        /// <summary>
        /// 生成类适配器
        /// </summary>
        static void GenCrossBindAdapter()
        {
            var types = new List<Type>();
            types.Add(typeof(ScriptableObject));
            types.Add(typeof(Exception));
            types.Add(typeof(System.Collections.IEnumerable));
            types.Add(typeof(System.Runtime.CompilerServices.IAsyncStateMachine));
            GenAdapter.CreateAdapter(types, "Assets/" +  ScriptKitILRuntime.PACKAGE_PATH_IN_ASSETS + "/ILRuntime/Adapter");
        }

        //生成clr绑定
        public static void GenCLRBindingByAnalysis(RuntimePlatform platform = RuntimePlatform.Lumin)
        {
            if (platform == RuntimePlatform.Lumin)
            {
                platform = Application.platform;
            }

            //用新的分析热更dll调用引用来生成绑定代码
            var dllpath = Application.streamingAssetsPath + "/AssetBundles/" + AssetBundleSettings.GetPlatformName() +
                          "/hotfix.dll";
            ILRuntimeHelper.LoadHotfix(dllpath, false);
            BindingCodeGenerator.GenerateBindingCode(ILRuntimeHelper.AppDomain,
                "Assets/" + ScriptKitILRuntime.CLR_BIDING_CODE_GEN_PATH.CreateDirIfNotExists());
            AssetDatabase.Refresh();
        }


        public void Init(IQFrameworkContainer container)
        {
            Core.RegisterUtility<IJsonSerializeUtility>(new JsonDotnetSerializeUtility());

            mRootLayout = new VerticalLayout();

            new LabelView("ScriptKitILRuntime 的编辑器").FontSize(12).AddTo(mRootLayout);

            var verticalLayout = new VerticalLayout("box").AddTo(mRootLayout);

            var versionText = "0";

            verticalLayout.AddChild(new HorizontalLayout()
                .AddChild(new LabelView("版本号(数字):"))
                .AddChild(new TextView(versionText, t => versionText = t))
            );

            verticalLayout.AddChild(new ButtonView("生成版本信息", () =>
            {
                var generatePath = Application.streamingAssetsPath + "/AssetBundles/" +
                                   AssetBundleSettings.GetPlatformName() + "/";


                var filenames = Directory.GetFiles(generatePath);


                //new DLLVersion()
                //{
                //    Assets = filenames.Select(f => f.GetFileName()).ToList(),
                //    Version = versionText.ToInt()
                //}.SaveJson(generatePath + "/hotfix.json");

                AssetDatabase.Refresh();
            }));


            new CustomView(() =>
            {
                GUILayout.BeginVertical();
                {
                    //第二排
                    GUILayout.BeginHorizontal();
                    {
                        if (GUILayout.Button("1. 编译热更 dll", GUILayout.Width(100), GUILayout.Height(30)))
                        {
                            if (EditorWindow.focusedWindow.GetType() == typeof(PackageKitWindow))
                            {
                                EditorWindow.focusedWindow.Close();
                            }

                            EditorActionKit.ExecuteNode(DelayAction.Allocate(0.1f, () =>
                            {
                                //1.build dll
                                var outpath_win = Application.streamingAssetsPath + "/AssetBundles/" +
                                                  AssetBundleSettings.GetPlatformName();
                                ScriptBuildTools.BuildDll(Application.dataPath, outpath_win);
                                //3.生成CLRBinding
                                GenCLRBindingByAnalysis();
                                AssetDatabase.Refresh();
                                Debug.Log("脚本打包完毕");
                            }));
                        }
                    }
                    GUILayout.EndHorizontal();

                    if (GUILayout.Button("2.生成CLRBinding · one for all[已集成]", GUILayout.Width(305),
                        GUILayout.Height(30)))
                    {
                        GenCLRBindingByAnalysis();
                    }

                    if (GUILayout.Button("3.生成跨域Adapter[没事别瞎点]", GUILayout.Width(305), GUILayout.Height(30)))
                    {
                        GenCrossBindAdapter();
                    }

                    if (GUILayout.Button("4.生成Link.xml", GUILayout.Width(305), GUILayout.Height(30)))
                    {
                        StripCode.GenLinkXml();
                    }

                    GUI.color = Color.green;
                    GUILayout.Label(
                        @"注意事项:
     1.编译服务使用codedom,请放心使用
     2.如编译出现报错，请仔细看报错信息,和报错的代码行列,
       一般均为语法错
     3.语法报错原因可能有:主工程访问hotfix中的类, 使用宏
       编译时代码结构发生变化..等等，需要细心的你去发现"
                    );
                    GUI.color = GUI.backgroundColor;
                }
                GUILayout.EndVertical();

            }).AddTo(verticalLayout);


            new EnumPopupView(ILRuntimeScriptSetting.SimulationMode).AddTo(mRootLayout).ValueProperty
                .Bind(v => ILRuntimeScriptSetting.SimulationMode = (AssetLoadPath) v);
        }

        public void OnUpdate()
        {

        }

        public void OnDispose()
        {

        }

        public void OnGUI()
        {
            mRootLayout.DrawGUI();
        }
    }
}