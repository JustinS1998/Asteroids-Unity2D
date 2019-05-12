using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int level;
    public int numAsteroids;
    public GameObject asteroid;
    public float startingForce;

    private void Start()
    {
        level = 0;
        numAsteroids = 1;
    }

    private void Update()
    {
        if (Input.GetKeyUp("y"))
        {
            for (int i = 0; i < numAsteroids; i++)
            {
                GameObject newAsteroid = Instantiate(asteroid);
                Rigidbody2D newrb = newAsteroid.GetComponent<Rigidbody2D>();
                newrb.MovePosition(new Vector2(3, 3));
                newrb.MoveRotation(Random.value*360);
                newrb.AddForce(newAsteroid.transform.up * startingForce);
            }
        }
    }
}
