using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode leftKey;
    [SerializeField] bool isLocal;

    [SerializeField] ScoreManager manager;

    public int speed;

    private Rigidbody rb;

    private void Update()
    {
        rb = GetComponent<Rigidbody>();
        MoveObject(GetInput());

        if (manager.isGameOver)
        {
            speed = 0;
        }
    }

    private Vector3 GetInput()
    {
        if (isLocal)
        {
            if (Input.GetKey(rightKey))
            {
                return Vector3.back * speed;
            }
            if (Input.GetKey(leftKey))
            {
                return Vector3.forward * speed;
            }
        }
        else
        {
            if (Input.GetKey(rightKey))
            {
                return Vector3.right * speed;
            }
            if (Input.GetKey(leftKey))
            {
                return Vector3.left * speed;
            }
        }        
        return Vector3.zero;
    }

    private void MoveObject(Vector3 movement)
    {
        rb.velocity = movement;
    }
}
