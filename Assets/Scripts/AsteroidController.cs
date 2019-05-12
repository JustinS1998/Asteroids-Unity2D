using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 oldVelocity;
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
        }
    }
    private void LateUpdate()
    {
        oldVelocity = rb.velocity;
    }
}
