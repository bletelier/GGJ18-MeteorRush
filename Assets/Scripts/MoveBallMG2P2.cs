using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBallMG2P2 : MonoBehaviour {

    private float speed = 5;
    public Rigidbody myBall;
    public Transform balltf;

    private Vector3 move;


    void Start()
    {
        myBall = GetComponent<Rigidbody>();
        balltf = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            move = new Vector3(-1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move = new Vector3(1, 0, 0);
        }
        else
        {
            move = new Vector3(0, 0, 0);
        }

        myBall.AddForce(move * speed);
        //balltf.Translate(move);
    }
}
