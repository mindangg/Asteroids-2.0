using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStation : MonoBehaviour
{
    private Rigidbody2D spaceStation;
    public Missiles missilesPrefab;
    private float shootingDelay = 15; 
    private float lastTimeShot = 0;

    private void Awake()
    {
        Instantiate(missilesPrefab, transform.position, transform.rotation);
    }

    private void Update()
    {
        if(Time.time > lastTimeShot + shootingDelay)
        {
            Instantiate(missilesPrefab, transform.position, transform.rotation);
            lastTimeShot = Time.time;
        }
    }

    private void FixedUpdate()
    {

    }
}
