using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bullet; 
    private float speed = 700;

    private void Awake()
    {
        bullet = GetComponent<Rigidbody2D>();
    }

    public void SetTrajectory(Vector2 direction)
    {
        bullet.AddForce(direction * speed);
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
