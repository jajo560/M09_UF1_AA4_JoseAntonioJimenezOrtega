using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGun : MonoBehaviour
{
    public LineRenderer line;
    public float lineFadeSpeed = 1f;
    public LayerMask mask;
    public float knockbackForce = 10f;

    private void Update()
    {
        line.startColor = new Color(line.startColor.r, line.startColor.g, line.startColor.b, line.startColor.a - Time.deltaTime * lineFadeSpeed);
        line.endColor = new Color(line.endColor.r, line.endColor.g, line.endColor.b, line.endColor.a - Time.deltaTime * lineFadeSpeed);

        if (Input.GetButtonDown("Fire1"))
        {
            line.startColor = new Color(line.startColor.r, line.startColor.g, line.startColor.b, 1);
            line.endColor = new Color(line.endColor.r, line.endColor.g, line.endColor.b, 1);

            RaycastHit hit;
            Vector3 rayOrigin = transform.position;
            Vector3 rayDirection = transform.forward;

            line.SetPosition(0, rayOrigin);
            line.SetPosition(1, rayOrigin + rayDirection * 1000);

            if (Physics.Raycast(rayOrigin, rayDirection, out hit, mask))
            {
                line.SetPosition(1, hit.point);
                EnemyController enemy = hit.collider.GetComponent<EnemyController>();
                if (hit.collider.CompareTag("Enemy"))
                {
                    if (enemy != null)
                    {
                        enemy.Kill();
                    }
                }

                if (hit.rigidbody != null)
                {
                    Vector3 knockbackDirection = hit.transform.position - transform.position;
                    knockbackDirection.Normalize();

                    hit.rigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
                }
            }
        }
    }
}
