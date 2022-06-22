using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode leftKey;
    [SerializeField] int speed;
    [SerializeField] bool isLocal;

    private Rigidbody rb;

    private void Update()
    {
        rb = GetComponent<Rigidbody>();
        MoveObject(GetInput());
    }

    private Vector3 GetInput()
    {
        if (isLocal)
        {
            if (Input.GetKey(rightKey))
            {
                return Vector3.back * speed;
            }
            else if (Input.GetKey(leftKey))
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
            else if (Input.GetKey(leftKey))
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
