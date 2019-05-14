using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int level;
    private int numAsteroids;
    public GameObject asteroid;
    public GameObject player;
    public float startingForce;
    public Text txt;
    private SpriteRenderer playerSprite;

    private void Start()
    {
        level = 0;
        playerSprite = player.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        scoreUpdate();

        if (numAsteroids == 0)
        {
            level += 1;
            spawnAsteroids(level);
            playerInvincible();
            Invoke("playerNormal", 2f);
        }
    }

    private void scoreUpdate ()
    {
        numAsteroids = GameObject.FindGameObjectsWithTag("Asteroid").Length;
        txt.text = "Asteroids: " + numAsteroids + " Level: " + level;
    }
    private void spawnAsteroid (float xcoor, float ycoor)
    {
        GameObject newAsteroid = Instantiate(asteroid, new Vector2(xcoor, ycoor), Quaternion.identity);
        Rigidbody2D newrb = newAsteroid.GetComponent<Rigidbody2D>();
        newrb.MoveRotation(Random.value * 360);
        newrb.AddForce(newAsteroid.transform.up * startingForce);
    }
    private void spawnAsteroids (int currentLevel)
    {
        for (int i=0; i<level; i++)
        {
            spawnAsteroid(Random.Range(3.5f, 4f), Random.Range(3.5f, 4f));
            spawnAsteroid(Random.Range(3.5f, 4f), Random.Range(-4f, -3.5f));
            spawnAsteroid(Random.Range(-4f, -3.5f), Random.Range(3.5f, 4f));
            spawnAsteroid(Random.Range(-4f, -3.5f), Random.Range(-4f, -3.5f));
        }
    }
    private void playerInvincible ()
    {
        player.layer = 12; //invincibility
        StartCoroutine("playerFlashing");
    }
    private void playerNormal ()
    {
        player.layer = 11; //normal layer
        StopCoroutine("playerFlashing");
        playerSprite.color = new Color(1, 1, 1, 1);
    }
    private IEnumerator playerFlashing ()
    {
        while(true)
        {
            playerSprite.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.25f);
            playerSprite.color = new Color(0.5f, 0.5f, 0.5f, 1);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
