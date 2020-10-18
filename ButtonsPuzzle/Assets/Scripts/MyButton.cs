using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyButton : MonoBehaviour
{
    [SerializeField] private ButtonState buttonStates;
    [SerializeField] private Selectable selectable;
    [SerializeField] private Image image;
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;
    private void Start()
    {
        selectable.OnTriggerEvent(EventTriggerType.PointerDown, OnClick);
    }
    public ButtonState GetButtonState()
    {
        return buttonStates;
    }
    private void OnClick(BaseEventData b)
    {
        Debug.Log("click");
        if(buttonStates == ButtonState.ON)
        {
            buttonStates = ButtonState.OFF;
            image.sprite = off;
        }
        else
        {
            image.sprite = on;
            buttonStates = ButtonState.ON;
        }
        DynamicStateMachine.Instance.ProcessSignal();
    }
}

public enum ButtonState
{
    ON,
    OFF,
}