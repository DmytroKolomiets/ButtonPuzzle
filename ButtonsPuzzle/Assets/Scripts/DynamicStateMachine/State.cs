using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class State : MonoBehaviour
{
    [SerializeField] private State stateToTransition;
    [SerializeField] private Condition condition;
    [SerializeField] private DynamicStateMachine machine;

    public void ProccessSignal()
    {
        Debug.Log("Proccesing signal");
        if (condition.isRichCondition())
        {
            Debug.Log("Transition To New State");
            machine.SetCurrentState(stateToTransition);
        }
    }
}
