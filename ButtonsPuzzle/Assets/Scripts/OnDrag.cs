using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class OnDrag : MonoBehaviour, IDragHandler
{
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if(eventData.delta.x > eventData.delta.y)
        Debug.Log("x");
    }
}
