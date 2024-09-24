using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStation : MonoBehaviour
{
    private Rigidbody2D spaceStation;
    private Vector2 direction;
    private Transform player;
    public Missiles missilesPrefab;

    private void Awake()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        Missiles missiles = Instantiate(missilesPrefab, transform.position, q);
    }
    // private void Update()
    // {
    //     if(true)
    //     {
    //         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
    //         Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

    //         Missiles missiles = Instantiate(missilesPrefab, transform.position, q);
    //     }
    // }

    private void FixedUpdate()
    {
        direction = (player.position - transform.position).normalized;
    }
}
