using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int Health;
    public int mS;

    [SerializeField]
    protected Rigidbody2D rb;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
        {
            Destroy(gameObject);
        }
    }
}
