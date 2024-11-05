using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{

    public float speedRotation;
    public GameObject enemy;
    private void Update()
    {
        Vector3 direction = enemy.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, direction);
        Vector3 turn = Vector3.Cross(transform.forward, direction);

        transform.RotateAround(transform.position, turn, Time.deltaTime * speedRotation * angle);
    }
}
