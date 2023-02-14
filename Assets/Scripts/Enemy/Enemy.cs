using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public enum MovementAction { straight, sinewave}

    public MovementAction movementAction = MovementAction.straight;

    public float speedX, speedY, speedO;

    void LateUpdate()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        if (movementAction == MovementAction.straight)
        {
            rb.velocity = new Vector2(0, -speedY);
        }
        else if (movementAction == MovementAction.sinewave)
        {
            rb.velocity = new Vector2(Mathf.Sin(Time.time*speedO) * speedX, -speedX);
        }
    }

}
