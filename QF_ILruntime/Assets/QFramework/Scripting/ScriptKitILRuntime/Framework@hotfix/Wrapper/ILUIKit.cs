using System;

namespace QFramework
{
    public interface ILUIPanelInterface : ICanGetILComponentFromGameObject
    {
        void Open(ILUIData uiData = null);
        void Close();
    }

    public interface ILUIData
    {
    }


    public abstract class ILUIPanel : ILComponent, ILUIPanelInterface
    {
        protected sealed override void OnStart()
        {
        }

        protected sealed override void OnDestroy()
        {
        }

        protected abstract void OnOpen(ILUIData uiData = null);

        protected abstract void OnClose();

        void ILUIPanelInterface.Open(ILUIData uiData = null)
        {
            OnOpen(uiData);
        }

        void ILUIPanelInterface.Close()
        {
            OnClose();
        }
    }

    public static class ILUIKit
    {
        public static void OpenPanel(string panelName)
        {
            var panel = UIKit.OpenPanel(panelName)
                .GetILComponent<ILUIPanelInterface>();
            panel.Open();
        }

        public static T OpenPanel<T>(UILevel uilevel, ILUIData uiData = null) where T : ILUIPanelInterface, new()
        {
            var panel = UIKit.OpenPanel(typeof(T).Name, uilevel)
                .GetILComponent<T>();
            panel.Open(uiData);
            return panel;
        }

        public static T OpenPanel<T>(ILUIData uiData = null) where T : ILUIPanelInterface, new()
        {
            var panel = UIKit.OpenPanel(typeof(T).Name)
                .GetILComponent<T>();
            panel.Open(uiData);
            return panel;
        }

        public static T GetPanel<T>() where T : ILUIPanel, new()
        {
            return UIKit.GetPanel(typeof(T).Name)
                .GetILComponent<T>();
        }

        public static void ClosePanel<T>() where T : ILUIPanel
        {
            var panelName = typeof(T).Name;
            var panel = UIKit.GetPanel(panelName);
            if (panel)
            {
                UIKit.ClosePanel(panelName);
                var ilPanel = panel.GetILComponent<ILUIPanelInterface>();
                ilPanel.Close();
            }
        }

        public static void CloseSelf<T>(this T self) where T : ILUIPanel
        {
            ClosePanel<T>();
        }
    }
}