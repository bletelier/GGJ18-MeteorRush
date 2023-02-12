using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public KeyCode up;
	public KeyCode down;

	float speed;
	float finalSpeed;

	// Use this for initialization
	void Start () {
		speed = 0.3f;
	}

	// Update is called once per frame
	void Update () {	
		if (Input.GetKey (up)) {
			if(transform.localPosition.y > 7.2){
				transform.Translate (0, 0, 0);
			}else{
				transform.Translate (0, speed, 0);
			}

		}
		if (Input.GetKey (down)) {
			if(transform.localPosition.y < -7.2){
				transform.Translate (0, 0, 0);
			}else{
				transform.Translate (0, -speed, 0);
			}
				
		}
	}
}
