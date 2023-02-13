using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int Health;
    public int Shield;
    public int mS;

    [SerializeField]
    protected Rigidbody2D rb;
}
