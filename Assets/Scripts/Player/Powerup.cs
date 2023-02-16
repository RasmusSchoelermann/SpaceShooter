using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

public class Powerup : MonoBehaviour
{
    public Rigidbody2D rb;

    private float speedY = 3f;

    Vector2 screenborder;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        screenborder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 5));

        powerupMove();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();
            player.powerUP = true;
            player.powerUPTime = 45f;

            Destroy(gameObject);
        }
    }

    private void powerupMove()
    {
        if (transform.position.y >= -screenborder.y - 2)
        {
            rb.velocity = new Vector2(0, -speedY);
        }
        else
        {
            Destroy(gameObject);
        }

    }


}