using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int level;
    public int numAsteroids;
    public GameObject asteroid;
    public float startingForce;
    public Text txt;

    private void Start()
    {
        level = 0;
    }

    private void Update()
    {
        scoreUpdate();

        if (Input.GetKeyUp("y"))
        {
            spawnAsteroid();
        }
    }

    private void scoreUpdate ()
    {
        numAsteroids = GameObject.FindGameObjectsWithTag("Asteroid").Length;
        txt.text = "Asteroids: " + numAsteroids;
    }
    private void spawnAsteroid ()
    {
        GameObject newAsteroid = Instantiate(asteroid);
        Rigidbody2D newrb = newAsteroid.GetComponent<Rigidbody2D>();
        newrb.MovePosition(new Vector2(3, 3));
        newrb.MoveRotation(Random.value * 360);
        newrb.AddForce(newAsteroid.transform.up * startingForce);
    }
}
