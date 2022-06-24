using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] GameObject[] goal;
    [SerializeField] ScoreManager scoreManager;

    private void Update()
    {
        if (scoreManager.isGameOver)
        {
            goal[0].SetActive(false);
            goal[1].SetActive(false);
            goal[2].SetActive(false);
            goal[3].SetActive(false);
        }
    }
}
