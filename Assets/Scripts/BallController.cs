using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] int earlySpeed;
    [SerializeField] int speed;    

    [SerializeField] Collider[] goal;
    [SerializeField] ScoreManager score;
    [SerializeField] BallSpawnerManager spawner;

    [HideInInspector] public Vector3 direction;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = direction * earlySpeed;
    }

    private void Update()
    {
        if(transform.position.y <= -10)
        {
            spawner.DestroyBall(gameObject);
            Debug.Log("Destroyed");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.tag == "Player" ||
           collision.gameObject.tag == "Tower" ||
           collision.gameObject.tag == "Ball" ||
           collision.gameObject.tag == "Wall")
        {
            if (rb.velocity.magnitude < speed)
            {
                rb.velocity = rb.velocity.normalized * speed;
            }
        }

        if (collision.gameObject.tag == "Player" ||
           collision.gameObject.tag == "Tower" ||
           collision.gameObject.tag == "Wall")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            rb.constraints = RigidbodyConstraints.None;
        }

        if (other == goal[0])
        {
            score.AddP1Score(1);
            spawner.RemoveBall(gameObject);
        }
        if (other == goal[1])
        {
            score.AddP2Score(1);
            spawner.RemoveBall(gameObject);
        }
        if (other == goal[2])
        {
            score.AddP3Score(1);
            spawner.RemoveBall(gameObject);
        }
        if (other == goal[3])
        {
            score.AddP4Score(1);
            spawner.RemoveBall(gameObject);
        }

        if (other.CompareTag("Destroyer"))
        {
            spawner.DestroyBall(gameObject);
        }
    }
}
