using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public Sprite[] sprites;
    private Rigidbody2D asteroids;
    private SpriteRenderer spriteRenderer;
    private GameManager gameManager;
    private float speed = 25;
    private float torque = 100;
    public float minSize = 1f;
    public float size = 1f;
    public float maxSize = 4f;
    
    private void Awake()
    {
        asteroids = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        transform.eulerAngles = new Vector3(0, 0, Random.value * 360);
        transform.localScale = Vector3.one * size;
    }

    public void SetTrajectory(Vector2 direction)
    {
        asteroids.AddForce(direction * speed);
        asteroids.AddTorque(Random.Range(-torque, torque));

        Destroy(gameObject, 30);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Player")
        {
            if(this.size / 2 >= minSize)
            {
                CreateSplit();
                CreateSplit();
            }
        }
        gameManager.AsteroidsDestroy(this);
        Destroy(gameObject);
    }

    private void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroids half = Instantiate(this, position, transform.rotation);
        half.size = this.size / 2;
        half.SetTrajectory(Random.insideUnitCircle.normalized * speed);
    }
}
