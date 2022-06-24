using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text[] score;

    [SerializeField] ScoreManager manager;

    private void Update()
    {
        score[0].text = manager.playerScore[0].ToString();
        score[1].text = manager.playerScore[1].ToString();
        score[2].text = manager.playerScore[2].ToString();
        score[3].text = manager.playerScore[3].ToString();
    }
}
