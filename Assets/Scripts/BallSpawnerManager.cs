using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerManager : MonoBehaviour
{
    [SerializeField] int ballAmount = 5;
    [SerializeField] int spawnInterval;

    [SerializeField] Transform ballParent;
    [SerializeField] GameObject ball;
    [SerializeField] List<GameObject> spawnPosition;

    private List<GameObject> ballList;
    private float timer;

    private void Start()
    {
        ballList = new List<GameObject>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            GenerateBallSpawnPosition();
            timer -= spawnInterval;
        }
    }

    public void RandomGenerateBall()
    {
        int spawner = Random.Range(0, 4);
    }

    public void GenerateBallSpawnPosition()
    {
        if(ballList.Count >= ballAmount)
        {
            return;
        }

        int randomIndex = Random.Range(0, 3);
        Vector3 position = new Vector3(spawnPosition[randomIndex].transform.position.x, spawnPosition[randomIndex].transform.position.y, spawnPosition[randomIndex].transform.position.z);

        if(randomIndex == 0)
        {
            ball.GetComponent<BallController>().direction = new Vector3(-1, 0, -1);
        }
        else if (randomIndex == 1)
        {
            ball.GetComponent<BallController>().direction = new Vector3(1, 0, -1);
        }
        else if (randomIndex == 2)
        {
            ball.GetComponent<BallController>().direction = new Vector3(-1, 0, 1);
        }
        else
        {
            ball.GetComponent<BallController>().direction = new Vector3(1, 0, 1);
        }

        GameObject SpawnedBall = Instantiate(ball, position, Quaternion.identity, ballParent);
        SpawnedBall.SetActive(true);

        ballList.Add(SpawnedBall);
    }
}
