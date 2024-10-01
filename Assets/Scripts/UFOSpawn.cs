using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawn : MonoBehaviour
{
    public UFO uFOPrefab;
    private int chance;
    private Vector3 spawnPoint;
    private Vector3 spawnPoint1 = new Vector3(-40, 23, 0);
    private Vector3 spawnPoint2 = new Vector3(-40, -23, 0);
    private Vector3 spawnPoint3 = new Vector3(40, 23, 0);
    private Vector3 spawnPoint4 = new Vector3(40, -23, 0);
    private Vector3 spawnPoint5 = new Vector3(0, 24, 0);
    private Vector3 spawnPoint6 = new Vector3(0, -24, 0);
    private Vector3 spawnPoint7 = new Vector3(40, 0, 0);
    private Vector3 spawnPoint8 = new Vector3(-40, 0, 0);
    // private bool UFOIsAlive = false;

    private void Start()
    {
        StartCoroutine("Spawn");
    }

    private void Update()
    {
        if(!uFOPrefab.UFOIsAlive)
            StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(5,5));
        chance = Random.Range(1,9);
        switch(chance)
        {
            case 1:
                spawnPoint = spawnPoint1;
                break;
            case 2:
                spawnPoint = spawnPoint2;
                break;
            case 3:
                spawnPoint = spawnPoint3;
                break;
            case 4:
                spawnPoint = spawnPoint4;
                break;
            case 5:
                spawnPoint = spawnPoint5;
                break;
            case 6:
                spawnPoint = spawnPoint6;
                break;
            case 7:
                spawnPoint = spawnPoint7;
                break;
            case 8:
                spawnPoint = spawnPoint8;
                break;
        }

        Instantiate(uFOPrefab, spawnPoint, transform.rotation);
        // Instantiate(uFOPrefab, transform.position, transform.rotation);
        uFOPrefab.UFOIsAlive = true;
    }
}
