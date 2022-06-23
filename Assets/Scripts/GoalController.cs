using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public GameObject[] goal;
    [SerializeField] ScoreManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            if (other == goal[0])
            {
                manager.AddP1Score(1);
            }
            if (other == goal[1])
            {
                manager.AddP1Score(1);
            }
            if (other == goal[2])
            {
                manager.AddP1Score(1);
            }
            if (other == goal[3])
            {
                manager.AddP1Score(1);
            }
        }
    }
}
