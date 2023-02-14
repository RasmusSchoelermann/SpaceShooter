using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public enum MovementAction { straight, sideways}

    public MovementAction movementAction = MovementAction.straight;

    public float speedX, speedY;

    public float targetYPosition;
    public float xScreenWidth;

    private float shipWidth;

    private bool moveright = true;

    private void Start()
    {
        Vector2 screenborder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 5));
        xScreenWidth = screenborder.x;

        shipWidth = rb.transform.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
    }


    void LateUpdate()
    {
        EnemyMovement();
        gameObject.GetComponent<Weapon>().fireWeapon();
    }

    public void EnemyMovement()
    {
        if (movementAction == MovementAction.straight)
        {
            if (transform.position.y >= targetYPosition)
            {
                rb.velocity = new Vector2(0, -speedY);
            }
            else
            {
                movementAction = MovementAction.sideways;
            }
        }
        else if (movementAction == MovementAction.sideways)
        {
            if (moveright)
            {
                rb.velocity = new Vector2(speedX, 0);
                if(transform.position.x > xScreenWidth - shipWidth)
                {
                    moveright = false;
                    Debug.Log(moveright);
                }
            }
            else
            {
                rb.velocity = new Vector2(-speedX, 0);
                if(transform.position.x < -xScreenWidth + shipWidth)
                {
                    moveright = true;
                    Debug.Log(moveright);
                }
            }
        }
    }

}
