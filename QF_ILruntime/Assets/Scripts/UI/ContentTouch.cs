using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class ContentTouch : MonoBehaviour,IDragAndDropEvent
{
    [Range(1,2)]
    public float scaleLimit = 1;

    public ScrollRect scrollRect;

    public RectTransform maskRTran;

    public void OnDrag(PointerEventData eventData)
    {
    }
    public void OnEndDrag(PointerEventData eventData)
    {
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
    }
    
    
}
