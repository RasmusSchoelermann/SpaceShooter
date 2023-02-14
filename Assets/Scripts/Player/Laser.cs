using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public int damage;

    private void Start()
    {
        if (transform.parent != null && transform.parent.tag == "Player")
        {
            rb.AddRelativeForce(new Vector2(0, speed), ForceMode2D.Impulse);
        }
        else
        {
            rb.AddRelativeForce(new Vector2(0, -speed), ForceMode2D.Impulse);
        }

        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(damage);

            Destroy(gameObject);
            
        }
        else if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
