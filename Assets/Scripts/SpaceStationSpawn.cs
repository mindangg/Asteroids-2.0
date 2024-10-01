using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationSpawn : MonoBehaviour
{
    public SpaceStation spaceStation;
    private int chance;
    private Vector3 spawnPoint;
    private Vector3 spawnPoint1 = new Vector3(30, 15.7f, 0);
    private Vector3 spawnPoint2 = new Vector3(-30, 15.7f, 0);
    private Vector3 spawnPoint3 = new Vector3(30, -15.7f, 0);
    private Vector3 spawnPoint4 = new Vector3(-30, -15.7f, 0);
    // private bool stationIsAlive = false;

    private void Start()
    {
        StartCoroutine("Spawn");
    }

    private void Update()
    {
        if(!spaceStation.stationIsAlive)
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
        }

        Instantiate(spaceStation, spawnPoint, transform.rotation);
        // Instantiate(uFOPrefab, transform.position, transform.rotation);
        spaceStation.stationIsAlive = true;
    }
}
