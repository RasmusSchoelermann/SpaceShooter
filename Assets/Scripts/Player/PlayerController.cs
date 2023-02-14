using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerController : Entity
{
    public Camera _cam;

    private Vector2 screenBounds;

    private float shipWidth;
    private float shipHeight;

    public bool powerUP;
    public float powerUPTime = 0f;

    private void Start()
    {
        screenBounds = _cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 5));

        shipWidth = rb.transform.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
        shipHeight = rb.transform.GetComponentInChildren<SpriteRenderer>().bounds.size.y / 2;

    }

    private void FixedUpdate()
    {
        HandleMovementInput();
        HandleFireInput();
        CheckMapBorder();

        

    }

    private void Update()
    {
        if(powerUP)
        {
            Weapon weapon = gameObject.GetComponent<Weapon>();
            powerUPTime -= Time.deltaTime;
            weapon.fireRate = 0.5f;
            if(powerUPTime <= 0 ) 
            {
                powerUP = false;
                weapon.fireRate = 1f;
            }
        }
    }

    private void HandleMovementInput()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * mS * Time.deltaTime, Input.GetAxis("Vertical") * mS * Time.deltaTime, 0);
    }

    private void HandleFireInput()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Weapon weapon = gameObject.GetComponent<Weapon>();
            weapon.fireWeapon();
        }
    }

    private void CheckMapBorder()
    {
        Vector3 viewPos = rb.transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + shipWidth, screenBounds.x - shipWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + shipHeight, screenBounds.y - shipHeight);

        rb.transform.position = viewPos;
    }


}
