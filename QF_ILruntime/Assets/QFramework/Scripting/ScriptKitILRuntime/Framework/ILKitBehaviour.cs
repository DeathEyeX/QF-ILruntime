using UnityEngine;

namespace QFramework
{
    public class ILKitBehaviour : ILComponentBehaviour
    {
        [Header("要写命名空间")] public string Namespace;

        private void Awake()
        {
            if (ScriptKit.Script == null)
            {
                ScriptKit.Script = new ILRuntimeScript();

                ScriptKit.LoadScript(() =>
                {
                    ScriptKit.CallStaticMethod(Namespace + "." + ScriptName, "Start", this);
                });
            }
            else
            {
                ScriptKit.CallStaticMethod(Namespace + "." + ScriptName, "Start", this);
            }
        }
        

        void OnApplicationQuit()
        {
#if UNITY_EDITOR
            if (ScriptKit.Script != null)
            {
                ScriptKit.Dispose();
            }
#endif
        }
    }
}