using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public Sprite[] sprites;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetTrajectory(Vector2 direction)
    {
        
    }
}
