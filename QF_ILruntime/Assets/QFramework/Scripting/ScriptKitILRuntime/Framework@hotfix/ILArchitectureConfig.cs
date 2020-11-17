using System;
using System.Collections.Generic;
using QFramework.ILRuntime;
using QFramework.ILRuntime.Framework;
using QFramework.Utility;
using UnityEngine;

namespace QFramework
{
    public abstract class ILArchitectureConfig<TCommand, TConfig>
        where TCommand : ILCommand
        where TConfig : ILArchitectureConfig<TCommand, TConfig>, new()
    {
        // 提供给大家主动调用一下
        public static void Init()
        {
            Debug.Log("@@@@ " + mConfig.GetType().Name + " 初始化");
        }

        public static T GetSystem<T>() where T : class, ILSystem
        {
            return mConfig.mSystemLayer.Resolve<T>();
        }

        public static void RegisterSystem<T>(T system) where T : class, ILSystem
        {
            mConfig.mSystemLayer.RegisterInstance<T>(system);
        }

        public static T GetModel<T>() where T : class, ILModel
        {
            return mConfig.mModelLayer.Resolve<T>();
        }
        public static void RegisterModel<T>(T model) where T : class, ILModel
        {
            mConfig.mModelLayer.RegisterInstance<T>(model);
        }

        public static T GetUtility<T>() where T : class, ILUtility
        {
            return mConfig.mUtilityLayer.Resolve<T>();
        }
        
        public static void RegisterUtility<T>(T utility) where T : class, ILUtility
        {
            mConfig.mUtilityLayer.RegisterInstance<T>(utility);
        }

        public static void SendCommand<T>() where T : ILCommand, new()
        {
            mConfig.mEventSystem.SendEvent<ILCommand>(new T());
        }

        public static void SendCommand(ILCommand command)
        {
            mConfig.mEventSystem.SendEvent<ILCommand>(command);
        }

        public static void SendEvent<T>() where T : new()
        {
            mConfig.mEventSystem.SendEvent<T>();
        }

        public static void SendEvent<T>(T @event)
        {
            mConfig.mEventSystem.SendEvent<T>(@event);
        }

        public static void RegisterEvent<T>(Action<T> onEvent)
        {
            mConfig.mEventSystem.RegisterEvent<T>(onEvent);
        }

        public static ILTypeEventSystem EventSystem
        {
            get { return mConfig.mEventSystem; }
        }

        private ILRuntimeIOCContainer mSystemLayer = new ILRuntimeIOCContainer();
        private ILRuntimeIOCContainer mModelLayer = new ILRuntimeIOCContainer();
        private ILRuntimeIOCContainer mUtilityLayer = new ILRuntimeIOCContainer();

        protected ILTypeEventSystem mEventSystem = new ILTypeEventSystem();

        private static ILArchitectureConfig<TCommand, TConfig> mPrivateConfig = null;

        protected static ILArchitectureConfig<TCommand, TConfig> mConfig
        {
            get
            {
                if (mPrivateConfig == null)
                {
                    mPrivateConfig = new TConfig();
                    mPrivateConfig.Config();
                }

                return mPrivateConfig;
            }
        }

        protected void Config()
        {
            // 注册命令模式
            mEventSystem.RegisterEvent<TCommand>(OnCommandExecute);
            OnUtilityConfig(mUtilityLayer);
            OnModelConfig(mModelLayer);
            OnSystemConfig(mSystemLayer);
        }

        protected virtual void OnCommandExecute(TCommand command)
        {
            command.Execute();
        }

        public void Dispose()
        {
            mEventSystem.UnRegisterEvent<TCommand>(OnCommandExecute);
            OnDispose();
        }

        protected virtual void OnDispose()
        {
        }

        protected abstract void OnSystemConfig(ILRuntimeIOCContainer systemLayer);
        protected abstract void OnModelConfig(ILRuntimeIOCContainer modelLayer);
        protected abstract void OnUtilityConfig(ILRuntimeIOCContainer utilityLayer);
        
        public abstract class ILEventSystemNode<TEventSystemNode> : ILPool<TEventSystemNode>
            where TEventSystemNode : ILEventSystemNode<TEventSystemNode>, new()
        {
            List<ICanDispose> mDisposes = new List<ICanDispose>();
            public void Register<TEvent>(Action<TEvent> onEvent)
            {
                var icanDispose = mConfig.mEventSystem.RegisterEvent<TEvent>(onEvent);
                mDisposes.Add(icanDispose);
            }

            void UnRegisterAll()
            {
                foreach (var canDispose in mDisposes)
                {
                    canDispose.Dispose();
                }

                mDisposes.Clear();
            }

            protected override void OnRecycle()
            {
                UnRegisterAll();
            }
        }
    }


}