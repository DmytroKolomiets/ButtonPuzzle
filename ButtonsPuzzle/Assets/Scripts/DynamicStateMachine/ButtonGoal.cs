using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[System.Serializable]
public class ButtonGoal : PropertyDrawer
{
    [SerializeField] private ButtonState goalState;
    [SerializeField] private MyButton button;

    public bool isGoalRiched()
    {
         if(goalState == button.GetButtonState()) return true;
         return false;
    }
}
