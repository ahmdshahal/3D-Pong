using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector3 direction;
    [SerializeField] int earlySpeed;
    [SerializeField] int speedGrounded;
    [SerializeField] int speed;    

    [SerializeField] Collider[] goal;

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
           collision.gameObject.tag == "Ball")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            if (rb.velocity.magnitude < speed)
            {
                rb.velocity = rb.velocity.normalized * speed;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        /*if (collision.gameObject.tag == "Ground")
        {
            rb.velocity = rb.velocity.normalized * speedGrounded;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == goal[0])
        {

        }
        if (other == goal[1])
        {

        }
        if (other == goal[2])
        {

        }
        if (other == goal[3])
        {

        }
    }
}
