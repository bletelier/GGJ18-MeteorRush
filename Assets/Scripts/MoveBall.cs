using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour {

    public Rigidbody myBall;

    private float speed = 5;
    private Vector3 move;


    void Start () {
        myBall = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move = new Vector3(0, 0, 1);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            move = new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = new Vector3(-1,0,0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            move = new Vector3(1, 0, 0);
        }
        
        myBall.AddForce(move * speed);
	}
}
