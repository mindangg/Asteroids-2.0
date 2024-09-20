using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public float score = 0;

    private Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void AsteroidsDestroy(Asteroids asteroids)
    {

    }

    public void PlayerDied()
    {
        lives--;

        if(lives <= 0)
            GameOver();
        else
            StartCoroutine("Respawn");
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        player.transform.position = Vector3.zero;
        player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        player.gameObject.SetActive(true);

        yield return new WaitForSeconds(3);
        player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {

    }

    private void NewGame()
    {

    }
}
