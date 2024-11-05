using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float speedRotation;
    public Transform target;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    { 
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        Vector3 direction = (transform.forward * vertical + transform.right * horizontal).normalized * speed;

        if (rb != null)
        {
            rb.velocity = direction;
        }

    }
}

