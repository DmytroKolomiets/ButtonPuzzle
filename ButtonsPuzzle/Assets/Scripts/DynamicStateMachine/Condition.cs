using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Condition : MonoBehaviour
{
     [SerializeField] private List<ButtonGoal> conditionList = new List<ButtonGoal>();
     
     public bool isRichCondition()
     {
        return conditionList.All(condition => condition.isGoalRiched());
     }
}
