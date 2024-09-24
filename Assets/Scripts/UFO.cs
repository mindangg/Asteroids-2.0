using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UFO : MonoBehaviour
{
    private Rigidbody2D uFO;
    private Vector2 direction;
    private float speed = 1.25f;
    private Transform player;
    public Lazer lazerPrefab;
    private float lazerSpeed = 250;
    private float shootingDelay = 1; 
    private float lastTimeShot = 0;

    private void Awake()
    {
        uFO = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(Time.time > lastTimeShot + shootingDelay)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

            Lazer lazer = Instantiate(lazerPrefab, transform.position, q);
            lazer.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, lazerSpeed));
            lastTimeShot = Time.time;
        }
    }

    private void FixedUpdate()
    {
        direction = (player.position - transform.position).normalized;
        uFO.MovePosition(uFO.position + direction * speed * Time.fixedDeltaTime);
    }
}
