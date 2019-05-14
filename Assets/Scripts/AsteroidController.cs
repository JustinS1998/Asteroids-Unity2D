using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 oldVelocity;
    public float minSize;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        oldVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Boundary")
        {
            rb.velocity = oldVelocity;
        }
        if (collision.collider.tag == "Bullet")
        {
            //break();
            Destroy(collision.collider.gameObject);
            if (this.gameObject.transform.lossyScale.x <= minSize)
            {
                Destroy(this.gameObject);
            }
            else
            {
                split();
            }
            
        }
    }
    private void Update()
    {
        oldVelocity = rb.velocity;
    }

    private void split()
    {
        GameObject newAsteroid = Instantiate(this.gameObject, rb.position, Quaternion.identity);
        this.gameObject.transform.localScale = newAsteroid.transform.localScale / 2f;
        newAsteroid.transform.localScale = newAsteroid.transform.localScale / 2f;
    }
}
