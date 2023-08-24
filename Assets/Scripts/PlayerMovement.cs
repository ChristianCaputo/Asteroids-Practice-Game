using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 0;
    private float turnDirection;
    private Rigidbody2D rigidBody;
    private bool moving;
    private bool reverse;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moving = false;
    }

    void Update()
    {
        // deteccion de inputs
        moving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        reverse = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1.0f;
        }
        else
        {
            turnDirection = 0;
        }
    }

    void FixedUpdate()
    {
        // funciones addForce (para avanzar) y Torque (para girar)
        if (moving)
        {
            speed = 4;
            rigidBody.AddForce(this.transform.up * speed);
        }
        if(reverse)
        {
            //rigidBody.AddForce(this.transform.up * -speed);
            speed = 0;
        }
        if (turnDirection != 0)
        {
            rigidBody.AddTorque(turnDirection);
        }
    }
}
