using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnDragSecond : MonoBehaviour, IDragHandler
{
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (eventData.delta.y > eventData.delta.x)
            Debug.Log("y");
    }
}
