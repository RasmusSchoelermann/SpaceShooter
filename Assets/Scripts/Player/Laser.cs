using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float damage;

    private void Start()
    {
        rb.AddRelativeForce(new Vector2(0, speed), ForceMode2D.Impulse);

        Destroy(gameObject, 20f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            //var enemy = other.GetComponent
        }
        else if(other.CompareTag("Meteorite"))
        {
            //var meteorite = other.GetComponent<>()
        }
    }
}
