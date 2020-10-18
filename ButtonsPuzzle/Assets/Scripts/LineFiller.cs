using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using NaughtyAttributes;
public class LineFiller : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    private EventTrigger eventTrigger;
    private Coroutine coroutine;
    private IDragHandler dragHandler;
    private PointerEventData pointerEvent;

    private void Start()
    {
        eventTrigger = button.OnTriggerEvent(EventTriggerType.Drag, FillImage);
        button.OnTriggerEvent(EventTriggerType.PointerUp, UnfillImage);
    }
    public void FillImage(BaseEventData b)
    {
        Debug.Log("Filling image");
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(RepeatAction(() =>
        {
            FillImage(image);
        }, 100, 0.01f
        ));
    }
    public void UnfillImage(BaseEventData b)
    {

        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(RepeatAction(() =>
        {
            UnfillImage(image);
        }, 100, 0.01f
        ));
    }
    [Button]
    private void ClearTirgger()
    {
        button.RemveListener(EventTriggerType.PointerDown, FillImage);
    }
    private void FillImage(Image image)
    {
        image.fillAmount += 0.01f;
    }
    private void UnfillImage(Image image)
    {
        image.fillAmount -= 0.01f;
    }
    private IEnumerator RepeatAction(UnityAction actioToRepeat, int timeToRepeat, float timeInterval)
    {
        for (int i = 0; i < timeToRepeat; i++)
        {
            yield return new WaitForSeconds(timeInterval);
            actioToRepeat.Invoke();
        }
    }
}

public static class Extention
{
    public static EventTrigger OnTriggerEvent(this Selectable UI_Element,
    EventTriggerType eventTriggerType, UnityAction<BaseEventData> action)
    {
        EventTrigger eventTrigger = UI_Element.GetEventTrigger();
        EventTrigger.Entry pointerdata = eventTrigger.GetEventTriggerEntry(eventTriggerType);
        pointerdata.callback.RemoveListener(action);
        pointerdata.callback.AddListener(action);
        return eventTrigger;
    }
    public static void RemveListener(this Selectable UI_Element, EventTriggerType eventTriggerType,
    UnityAction<BaseEventData> action)
    {
        EventTrigger eventTrigger = null;
        if (!UI_Element.TryGetComponent<EventTrigger>(out eventTrigger))
        {
            Debug.LogWarning("Object have no EvenTriggerer component");
            return;
        }
        foreach (var item in eventTrigger.triggers)
        {
            if (item.eventID == eventTriggerType)
            {
                item.callback.RemoveListener(action);
            }
        }
    }
    private static EventTrigger GetEventTrigger(this Selectable UI_Element)
    {
        EventTrigger eventTrigger = UI_Element.gameObject.GetComponent<EventTrigger>();
        if (eventTrigger == null)
        {
            eventTrigger = UI_Element.gameObject.AddComponent<EventTrigger>();
        }
        return eventTrigger;
    }
    private static EventTrigger.Entry GetEventTriggerEntry(this EventTrigger eventTrigger, EventTriggerType eventTriggerType)
    {
        foreach (var item in eventTrigger.triggers)
        {
            if (item.eventID == eventTriggerType)
                return item;
        }
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventTriggerType;
        eventTrigger.triggers.Add(entry);
        return entry;
    }
}

