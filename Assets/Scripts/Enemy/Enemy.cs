using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

    public int score = 10;

    public enum MovementAction { straight, sideways}

    public MovementAction movementAction = MovementAction.straight;

    public float speedX, speedY;

    public float targetYPosition;

    public Vector2 screenborder;

    private float shipWidth;
    private float shipHeight;

    private bool moveright = true;
    private bool movingoffMap = false;

    private float timeuntilFlyingoff = 40f;
    private float currentTime;


    private void Start()
    {
        screenborder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 5));


        shipWidth = rb.transform.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
        shipHeight = rb.transform.GetComponentInChildren<SpriteRenderer>().bounds.size.y / 2;

        targetYPosition = Random.Range(screenborder.y / 2, screenborder.y - shipHeight);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
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

            //Cleanup

            if(transform.position.y <= -screenborder.y -shipHeight && movingoffMap == true)
            {
                Destroy(gameObject);
            }
        }
        else if (movementAction == MovementAction.sideways)
        {
            if (moveright)
            {
                rb.velocity = new Vector2(speedX, 0);
                if(transform.position.x > screenborder.x - shipWidth)
                {
                    moveright = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(-speedX, 0);
                if(transform.position.x < -screenborder.x + shipWidth)
                {
                    moveright = true;
                }
            }

            CheckForTimer();
        }
    }

    private void CheckForTimer()
    {
        if(currentTime >= timeuntilFlyingoff)
        {
            targetYPosition = -screenborder.y - shipHeight;
            movementAction = MovementAction.straight;
            movingoffMap = true;
        }
    }

    private void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("GameLoop").GetComponent<GameLoop>().AddScore(score);
    }

}
