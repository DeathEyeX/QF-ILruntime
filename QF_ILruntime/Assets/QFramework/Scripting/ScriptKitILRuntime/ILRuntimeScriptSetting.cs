using UnityEngine;

namespace QFramework
{
    public enum AssetLoadPath
    {
        SimulationMode = 0,
        StreamingAsset
    }

    public enum HotfixCodeRunMode
    {
        ByILRuntime = 0,
        ByReflection,
    }
    
    public class ILRuntimeScriptSetting
    {
        /// <summary>
        /// 检测是否热更过
        /// </summary>
        public static bool LoadDLLFromStreammingAssetsPath
        {
            get { return PlayerPrefs.GetInt("LoadDLLFromStreammingAssetsPath", 1) == 1; }
            set { PlayerPrefs.SetInt("LoadDLLFromStreammingAssetsPath", value ? 1 : 0); }
        }


        public static string DllFileStreamingFullPath
        {
            get
            {
                return Application.streamingAssetsPath + "/AssetBundles/" +
                       AssetBundleSettings.GetPlatformName() + "/hotfix.dll";
            }
        }

        public static string DllFilePersistentFullPath
        {
            get
            {
                return Application.persistentDataPath + "/AssetBundles/" +
                       AssetBundleSettings.GetPlatformName() + "/hotfix.dll";
            }
        }

        private static AssetLoadPath mAssetLoadPath = AssetLoadPath.StreamingAsset;

        /// <summary>
        /// ILKit 的模式
        /// </summary>
        public static AssetLoadPath SimulationMode
        {
            get
            {
#if UNITY_EDITOR
                return UnityEditor.EditorPrefs.GetBool("ILKIT_SIMULATION_MODE", false)
                    ? AssetLoadPath.SimulationMode
                    : mAssetLoadPath;
#endif
                return mAssetLoadPath;
            }
            set
            {
#if UNITY_EDITOR
                UnityEditor.EditorPrefs.SetBool("ILKIT_SIMULATION_MODE", value == AssetLoadPath.SimulationMode);
#endif
                mAssetLoadPath = value;
            }
        }
    }
}