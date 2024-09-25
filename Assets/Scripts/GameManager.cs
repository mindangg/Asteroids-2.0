using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public float score = 0;

    private Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void SpaceStationDestroy(SpaceStation spaceStation)
    {
        score += 500;
    }

    public void MissilesDestroy(Missiles missiles)
    {
        score += 100;
    }

    public void UFODestroy()
    {
        score += 300;
    }

    public void AsteroidsDestroy(Asteroids asteroids)
    {
        //Explosion

        if(asteroids.size < 1.4f)
        {
            score += 150;
        }
        else if(asteroids.size < 2.8f)
        {
            score += 100;
        }
        else
        {
            score += 50;
        }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
