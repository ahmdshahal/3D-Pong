using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{    
    [SerializeField] int maxScore;
    [SerializeField] Text winner;
    [SerializeField] GameObject gameOver;
    [SerializeField] bool[] losePlayer;
    [SerializeField] GameObject[] wall;
    [SerializeField] GameObject[] player;

    [HideInInspector] public bool isGameOver;

    public int[] playerScore;    

    private int playerLose;

    public void AddP1Score(int increment)
    {
        playerScore[0] += increment;
        
        if(playerScore[0] >= maxScore)
        {
            wall[0].SetActive(true);
            player[0].SetActive(false);
            losePlayer[0] = true;
            playerLose += 1;
        }
    }

    public void AddP2Score(int increment)
    {
        playerScore[1] += increment;

        if (playerScore[1] >= maxScore)
        {
            wall[1].SetActive(true);
            player[1].SetActive(false);
            losePlayer[1] = true;
            playerLose += 1;
        }
    }

    public void AddP3Score(int increment)
    {
        playerScore[2] += increment;

        if (playerScore[2] >= maxScore)
        {
            wall[2].SetActive(true);
            player[2].SetActive(false);
            losePlayer[2] = true;
            playerLose += 1;
        }
    }

    public void AddP4Score(int increment)
    {
        playerScore[3] += increment;

        if (playerScore[3] >= maxScore)
        {
            wall[3].SetActive(true);
            player[3].SetActive(false);
            losePlayer[3] = true;
            playerLose += 1;
        }
    }

    private void Update()
    {
        if(playerLose == 3)
        {
            isGameOver = true;
            gameOver.SetActive(true);

            if (losePlayer[0] == false)
            {
                winner.text = "Player 1";
            } 
            else if (losePlayer[1] == false)
            {
                winner.text = "Player 2";
            } 
            else if (losePlayer[2] == false)
            {
                winner.text = "Player 3";
            }
            else
            {
                winner.text = "Player 4";
            }
        }
    }
}
