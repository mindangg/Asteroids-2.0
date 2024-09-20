using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D player;
    public Bullet bulletPrefab;
    private bool thrusting;
    private bool reverse;
    private float turnDirection;
    public float thrustPower = 10;
    public float turnSpeed = 0.5f;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        reverse = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            turnDirection = 1;
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            turnDirection = -1;
        else
            turnDirection = 0;

        if(Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void FixedUpdate()
    {
        if(thrusting)
            player.AddForce(transform.up * thrustPower);
        if(reverse)
            player.AddForce(transform.up * -thrustPower);
        if(turnDirection != 0)
            player.AddTorque(turnDirection * turnSpeed);
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.SetTrajectory(transform.up);
    }
}
