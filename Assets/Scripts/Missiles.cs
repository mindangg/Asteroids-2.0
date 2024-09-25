using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missiles : MonoBehaviour
{
    private Rigidbody2D missiles;
    private Vector2 direction;
    private float speed = 5f;
    private Transform player;

    private void Awake()
    {
        missiles = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        missiles.MoveRotation(q);
    }

    private void FixedUpdate()
    {
        direction = (player.position - transform.position).normalized;
        missiles.MovePosition(missiles.position + direction * speed * Time.fixedDeltaTime);
    }
}
