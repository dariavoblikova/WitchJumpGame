using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 100.0f;             //Floating point variable to store the player's movement speed.
    public Vector3 v3;
    public Vector3 w3;
    public float myX;
    public float myY;
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private Transform xform;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        xform = GetComponent<Transform>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Use the two store floats to create a new Vector2 variable movement.

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        v3 = Input.mousePosition;
        v3.z = 1000;
        w3 = Camera.main.ScreenToWorldPoint(v3);

        if (Input.GetKeyDown("space"))
        {
            Vector2 movement = new Vector2(-10f, 10f);
            rb2d.AddForce(movement * speed);

        }

        if (Input.GetMouseButtonDown(0))
        {

            float xDiff = xform.position.x - w3.x;
            double moveX = 0;
            double moveY = 0;
            if (xDiff > 0)
            {
                moveX = 3 * Math.Pow((double)xDiff, 2);
            }
            else
            {
                moveX = -3 * Math.Pow((double)xDiff, 2);
            }
            float yDiff = xform.position.y - w3.y;
            if (yDiff > 0)
            {
                moveY = -1.5 * Math.Pow((double)xDiff, 2) + 10;
            }
            else
            {
                moveY = 1.5 * Math.Pow((double)xDiff, 2) - 10;
            }
            Vector2 movement = new Vector2((float)moveX, (float)moveY);
            if (xDiff > 2.5 || xDiff < -2.5)
            {
                movement.x = 0;
            }
            if (yDiff > 2.5 || yDiff < -2.5)
            {
                movement.y = 0;
            }
            rb2d.AddForce(movement * speed);
        }

        myX = xform.position.x - w3.x;
        myY = xform.position.y - w3.y;


    }

}
