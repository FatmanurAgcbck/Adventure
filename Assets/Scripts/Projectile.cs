using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    private void OnCollisionEnter(Collision other)
    {
        EnemyController enemy = other.collider.GetComponent<EnemyController>();

        if (enemy != null)
        {
            enemy.Fix();
        }
        Destroy(gameObject);
    }
}
