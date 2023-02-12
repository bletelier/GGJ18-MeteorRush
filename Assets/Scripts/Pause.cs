using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    bool a = true;
    GameObject p1;
    GameObject p2;
    GameObject bu1;
    GameObject bu2;
    // Use this for initialization
    void Start () {
        p1 = GameObject.Find("p1");
        p2 = GameObject.Find("p2");
        bu1 = GameObject.Find("bu1");
        bu2 = GameObject.Find("bu2");
    }
    IEnumerator makeA()
    {
        p1.SetActive(false);
        p2.SetActive(false);
        GameObject.Find("SmashScreen").SetActive(true);
        yield return new WaitForSeconds(3);
        StartCoroutine(makeAb());
        GameObject.Find("SmashScreen").SetActive(false);
        
        
        
        
    }
    IEnumerator makeAb()
    {
        yield return new WaitForSeconds(1);
        bu1.SetActive(false);
        bu2.SetActive(false);
        p1.SetActive(true);
        p2.SetActive(true);
    }

        // Update is called once per frame
        void Update () {
        if(a)
        {
            StartCoroutine(makeA());
            a = false;
        }
    }
}
