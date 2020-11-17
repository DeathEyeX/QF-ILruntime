using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BossCat
{
    public class UIEventListener : EventTrigger
    {
        //定义相关委托类型
        public delegate void VoidDelegate(GameObject go);
        public delegate void BoolDelegate(GameObject go, bool isValue);
        public delegate void FloatDelegate(GameObject go, float fValue);
        public delegate void IntDelegate(GameObject go, int iIndex);
        public delegate void StringDelegate(GameObject go, string strValue);

        //定义相关委托变量
        public VoidDelegate onSubmit;
        public VoidDelegate onClick;
        public BoolDelegate onHover;
        public BoolDelegate onToggleChanged;
        public FloatDelegate onSliderChanged;
        public FloatDelegate onScrollbarChanged;
        public VoidDelegate onScrollbarBeginChanged;
        public VoidDelegate onScrollbarEndChanged;
        public IntDelegate onDrapDownChanged;
        public StringDelegate onInputFieldChanged;

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnSubmit(BaseEventData eventData)
        {
            onSubmit?.Invoke(gameObject);
        }

        /// <summary>
        /// 鼠标移入
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnPointerEnter(PointerEventData eventData)
        {
            onHover?.Invoke(gameObject, true);
        }

        /// <summary>
        /// 点击
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnPointerClick(PointerEventData eventData)
        {
            //鼠标点击
            onClick?.Invoke(gameObject);
            //Toggle点击
            onToggleChanged?.Invoke(gameObject, gameObject.GetComponent<Toggle>().isOn);

        }

        /// <summary>
        /// 鼠标移出
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnPointerExit(PointerEventData eventData)
        {
            onHover?.Invoke(gameObject, false);
        }

        /// <summary>
        /// 开始拖拽
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnBeginDrag(PointerEventData eventData)
        {
            onScrollbarBeginChanged?.Invoke(gameObject);
        }

        /// <summary>
        /// 拖动
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnDrag(PointerEventData eventData)
        {
            //Slider滑动
            onSliderChanged?.Invoke(gameObject, gameObject.GetComponent<Slider>().value);
            //ScrollChanged滑动
            onScrollbarChanged?.Invoke(gameObject, gameObject.GetComponent<Scrollbar>().value);

        }

        /// <summary>
        /// 结束拖拽
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnEndDrag(PointerEventData eventData)
        {
            onScrollbarEndChanged?.Invoke(gameObject);
        }

        /// <summary>
        /// 选中
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnSelect(BaseEventData eventData)
        {
            onDrapDownChanged?.Invoke(gameObject, gameObject.GetComponent<Dropdown>().value);
        }

        /// <summary>
        /// 选中、每帧更新
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnUpdateSelected(BaseEventData eventData)
        {
            onInputFieldChanged?.Invoke(gameObject, gameObject.GetComponent<InputField>().text);
        }

        /// <summary>
        /// 不选中
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnDeselect(BaseEventData eventData)
        {
            onInputFieldChanged?.Invoke(gameObject, gameObject.GetComponent<InputField>().text);
        }

        /// <summary>
        /// 获取或添加一个事件监听器到指定的游戏对象
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public static UIEventListener Get(GameObject go)
        {
            UIEventListener listener = go.GetComponent<UIEventListener>();
            if (listener == null)
            {
                listener = go.AddComponent<UIEventListener>();
            }
            return listener;
        }

    }

}