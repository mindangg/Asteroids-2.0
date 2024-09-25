using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UFOSpawn : MonoBehaviour
{
    public UFO uFOPrefab;
    private void Awake()
    {
        
    }

    private void Spawn()
    {
        Instantiate(uFOPrefab,transform.position,transform.rotation);
    }
}
