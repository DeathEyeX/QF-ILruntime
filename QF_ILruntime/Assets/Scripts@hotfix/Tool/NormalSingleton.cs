using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BossCat
{
    public class NormalSingleton<T> where T : class, new()
    {
        protected static T _instance = null;
        public static T Instance
        {
            get
            {
                if (null == _instance)
                {
                    T t = new T();
                    if (t is MonoBehaviour)
                    {
                        Debug.LogError(message: "Mono类请使用MonoSingleton");
                        return null;
                    }
                    _instance = t;
                }
                return _instance;
            }
        }

        protected NormalSingleton()
        {
            if (null != _instance)
            {
                Debug.Log(typeof(T).ToString() + "Singleton Instance is not null !!!");
            }
            Init();
        }

        public virtual void Init()
        {

        }
    }
}