using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    Rigidbody rb;
    public float speedBullet = 3;
    public Vector3 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = dir;
        dir.Normalize();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Meteor"))
        {
            Destroy(gameObject);
        }
    }
}

