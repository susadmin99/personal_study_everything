using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    [SerializeField] float moveForce;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Think();
    }

    void Think()
    {
        float diff = transform.position.y - ResourcesController.Instance.ball.position.y;
        if (diff > 2 && diff < 6)
        {
            MoveDown();
        }
        else if(diff < - 2 && diff > -6)
        {
            MoveUp();
        }
    }

    void MoveUp()
    {
        rb.AddForce(new Vector3(0, moveForce, 0), ForceMode.VelocityChange);
    }

    void MoveDown()
    {
        rb.AddForce(new Vector3(0, -moveForce, 0), ForceMode.VelocityChange);
    }

    void StopMove()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
