using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.rigidbody.position *= -0.9f;
    }
}
