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

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.tag == "Player" ||
           collision.gameObject.tag == "Tower" ||
           collision.gameObject.tag == "Ball" ||
           collision.gameObject.tag == "Wall")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            if (rb.velocity.magnitude < speed)
            {
                rb.velocity = rb.velocity.normalized * speed;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == goal[0])
        {
            score.AddP1Score(1);
            spawner.RemoveBall(gameObject);
            Debug.Log("Point +");
        }
        if (other == goal[1])
        {
            score.AddP2Score(1);
            spawner.RemoveBall(gameObject);
            Debug.Log("Point +");
        }
        if (other == goal[2])
        {
            score.AddP3Score(1);
            spawner.RemoveBall(gameObject);
            Debug.Log("Point +");
        }
        if (other == goal[3])
        {
            score.AddP4Score(1);
            spawner.RemoveBall(gameObject);
            Debug.Log("Point +");
        }
    }
}
