using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    public GameObject grenade;
    public Rigidbody rb;
    public float launchForce;
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(grenade, transform.position, transform.rotation);
            rb.AddForce(transform.forward * launchForce, ForceMode.Impulse);

        }
    }
}
