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

        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy") && transform.parent.tag != "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(damage);

            Destroy(gameObject);
            
        }
        else if(other.CompareTag("Player") && transform.parent.tag != "Player")
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();
            player.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
