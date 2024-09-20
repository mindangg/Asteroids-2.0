using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D player;
    private SpriteRenderer spriteRenderer;
    private GameManager gameManager;
    public Bullet bulletPrefab;
    private bool thrusting;
    private bool reverse;
    private float turnDirection;
    public float thrustPower = 10;
    public float turnSpeed = 0.5f;
    private bool isHyper = false;
    private float screenTop = 19.2f;
    private float screenBottom = -19.2f;
    private float screenLeft = -32.9f;
    private float screenRight = 32.9f;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
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
        
        if(Input.GetKeyDown(KeyCode.H))
            if(!isHyper)
                StartCoroutine("HyperSpace");

        ScreenWrapping();
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

    private IEnumerator HyperSpace()
    {
        spriteRenderer.enabled = false;
        //Effect
        transform.position = new Vector3(Random.Range(-31.18f, 31.18f), Random.Range(-16.9f, 16.9f), 0);
        yield return new WaitForSeconds(0.5f);
        //Effect
        spriteRenderer.enabled = true;
        isHyper = true;
        yield return new WaitForSeconds(5);
        isHyper = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        player.velocity = Vector3.zero;
        player.angularDrag = 0;

        this.gameObject.SetActive(false);

        gameManager.PlayerDied();
    }

    private void ScreenWrapping()
    {
        Vector2 newPos = transform.position;
        if(transform.position.x < screenLeft)
        {
            newPos.x = screenRight;
        }
        if(transform.position.x > screenRight)
        {
            newPos.x = screenLeft;
        }
        if(transform.position.y > screenTop)
        {
            newPos.y = screenBottom;
        }
        if(transform.position.y < screenBottom)
        {
            newPos.y = screenTop;
        }
        transform.position = newPos;
    }
}
