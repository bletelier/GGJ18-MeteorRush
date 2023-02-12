using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBallP2 : MonoBehaviour {

    public Rigidbody myBall;

    private float speed = 5;
    private Vector3 move;


    void Start()
    {
        myBall = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            move = new Vector3(0, 0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            move = new Vector3(0, 0, -1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            move = new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            move = new Vector3(1, 0, 0);
        }

        myBall.AddForce(move * speed);
    }
}