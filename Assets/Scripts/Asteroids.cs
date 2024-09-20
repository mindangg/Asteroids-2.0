using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public Sprite[] sprites;
    private Rigidbody2D asteroids;
    private SpriteRenderer spriteRenderer;
    private float speed = 25;
    private float torque = 100;
    public float minSize = 1f;
    public float size = 1f;
    public float maxSize = 3.6f;
    
    private void Awake()
    {
        asteroids = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        transform.eulerAngles = new Vector3(0, 0, Random.value * 360);
        transform.localScale = Vector3.one * size;

        //asteroids.mass = size;
    }

    public void SetTrajectory(Vector2 direction)
    {
        asteroids.AddForce(direction * speed);
        asteroids.AddTorque(Random.Range(-torque, torque));

        Destroy(gameObject, 30);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
