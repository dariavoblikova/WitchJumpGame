using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WitchBehavior : MonoBehaviour
{

    public float speed = 100.0f;             //Floating point variable to store the player's movement speed.
    public Vector3 v3, w3;
    public float myX, myY;
    public AudioClip explosionSound;
    private GameObject witch, explosionVFX;
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private Transform xform;

    private AudioSource soundEffect;

    // Use this for initialization
    void Start()
    {
        witch = GameObject.FindWithTag("Player");   //  Witch

        rb2d = GetComponent<Rigidbody2D>();
        xform = GetComponent<Transform>();
        soundEffect = GetComponent<AudioSource>();
        explosionVFX = GameObject.FindWithTag("ExplosionParticle");
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Use the two store floats to create a new Vector2 variable movement.

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        v3 = Input.mousePosition;
        v3.z = 1000;
        w3 = Camera.main.ScreenToWorldPoint(v3);

        if (Input.GetMouseButtonDown(0))
        {


            //  Play sound effect
            soundEffect.PlayOneShot(explosionSound, .80f);
            //  Create explosion

            explosionVFX.GetComponent<Transform>().position = getWitchPositionForExplosion();
            explosionVFX.GetComponent<ParticleSystem>().Play(true);

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
            if (xDiff > 2 || xDiff < -2)
            {
                movement.x = 0;
                movement.y = 0;
            }
            if (yDiff > 2 || yDiff < -2)
            {
                movement.y = 0;
                movement.x = 0;
            }
            rb2d.AddForce(movement * speed);
        }

        myX = xform.position.x - w3.x;
        myY = xform.position.y - w3.y;


    }

    Vector3 getWitchPositionForExplosion()
    {
        Vector3 explosionPosition = witch.GetComponent<Transform>().position;

        explosionPosition.z -= 5;

        return explosionPosition;
    }

}
