using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public float speedRotation;
    public float moveSpeed;
    public float slowSpeed;
    public float stoppingDistance;
    public GameObject player;
    public Rigidbody rb;
    public Animator animator;


    private void Start()
    {

    }
    private void Update()
    {

        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, direction);
        Vector3 turn = Vector3.Cross(transform.forward, direction);

        transform.RotateAround(transform.position, turn, Time.deltaTime * speedRotation * angle);

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > stoppingDistance)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        if (distance <= stoppingDistance) 
        {
            transform.position += transform.forward * slowSpeed * Time.deltaTime;

        }


    }
    public void Kill()
    {
        rb = GetComponent<Rigidbody>();

        rb.isKinematic = true;

        animator.enabled = false;

        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;

        this.gameObject.GetComponent<EnemyController>().enabled = false;

    }
}
