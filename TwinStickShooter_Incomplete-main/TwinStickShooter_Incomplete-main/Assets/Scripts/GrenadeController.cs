using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GrenadeController : MonoBehaviour
{
    private bool hasExploded;
    public LayerMask mask;
    public float timer;
    public float radius;
    public float explosionForce;
    public GameObject particles;
    public GameObject grenade;

    private void Update()
    {
   
        if (!hasExploded)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                Explode();
            }
        }
    }

    void Explode()
    {
        hasExploded = true;

        if (particles != null)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
        }
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, radius, mask);
        foreach (var enemyCollider in enemiesInRange)
        {
            if (enemyCollider.CompareTag("Enemy"))
            {
                EnemyController enemy = enemyCollider.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.Kill();
                }
            }
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hit in colliders)
        {
            Rigidbody hitRb = hit.GetComponent<Rigidbody>();
            if (hitRb != null)
            {
                Vector3 direction = hit.transform.position - transform.position;
                float distance = direction.magnitude;
                direction.Normalize();

                float force = explosionForce * (1f - (distance / radius));
                hitRb.AddForce(direction * force, ForceMode.Impulse);
            }
        }

        Destroy(grenade);
    }
}


  