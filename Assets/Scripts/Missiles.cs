using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missiles : MonoBehaviour
{
    private Rigidbody2D missiles;
    private Vector2 direction;
    private float speed = 2.5f;
    private Transform player;

    private void Awake()
    {
        missiles = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        direction = (player.position - transform.position).normalized;
        missiles.MovePosition(missiles.position + direction * speed * Time.fixedDeltaTime);
    }
}
