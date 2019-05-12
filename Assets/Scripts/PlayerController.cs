using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public GameObject bullet;
    public float speed = 1;
    public float firingWait = 0.1f;
    private float angle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVerical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVerical);
        rb.AddForce(movement * speed);

        //Rotation
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mousePos.y - rb.position.y, mousePos.x - rb.position.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
        //print($"Angle: {angle}, Position: {rb.position}, MousePosition: {mousePos}");

    }

    private void Update()
    {
        //Firing
        if (Input.GetMouseButtonDown(0))
        {
            InvokeRepeating("firing", 0f, firingWait);
        }
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke();
        }
    }
        

    void firing ()
    {
        GameObject newBullet = Instantiate(bullet, rb.position, Quaternion.Euler(0, 0, angle));
        newBullet.SetActive(true);
    }
}
