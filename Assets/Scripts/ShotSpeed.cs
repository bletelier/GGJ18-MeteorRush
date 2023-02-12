using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpeed : MonoBehaviour {

    public float shootSpeed;

    private Rigidbody myShot;

    private void Start()
    {
        myShot = GetComponent<Rigidbody>();

        myShot.velocity = transform.forward * shootSpeed;
    }
}
