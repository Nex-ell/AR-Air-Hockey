using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
   
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private bool isLeftGoal; 

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Puck"))
        {
            
            scoreManager.GoalScored(isLeftGoal);
        }
    }
}

