using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullController : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    int direction;
    private void Start()
    {
        InvokeRepeating("Jump", Random.Range(0, 2), Random.Range(3, 6));
        InvokeRepeating("Right", Random.Range(0, 2), Random.Range(3, 6));
    }

    void Jump()
    {
        jumpForce =+ Random.Range(5, 10);
        rb.velocity = Vector3.up * jumpForce;

    }
    void Right()
    {
        direction = Random.Range(-1, 2);
        rb.velocity = Vector3.right * jumpForce * direction;
    }
}
