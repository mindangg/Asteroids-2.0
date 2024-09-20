using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawn : MonoBehaviour
{
    public Asteroids asteroidsPrefab;
    private float spawnRate = 3;
    public int spawnAmmount = 1;
    private float spawnDistance = 40;
    private float trajectoryVariance = 35;
    

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void Spawn()
    {
        for(int i = 0; i < spawnAmmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroids asteroids = Instantiate(asteroidsPrefab, spawnPoint, rotation);
            asteroids.size = Random.Range(asteroids.minSize, asteroids.maxSize);
            asteroids.SetTrajectory(rotation * -spawnDirection);  
        }
    }
}
