using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class DynamicStateMachine : MonoBehaviour
{
    public static DynamicStateMachine Instance;
    [SerializeField] private State currentState;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else Instance = this;

    }
    public void SetCurrentState(State state)
    {
        currentState = state;
    }
    [Button]
    public void ProcessSignal()
    {
        currentState.ProccessSignal();
    }
}
