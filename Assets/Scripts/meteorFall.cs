using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class meteorFall : MonoBehaviour {
    public float imgPosM;
    public float imgPosm;
    private float resta;
    Vector3 reco;
    private float actualTime;
    GameObject meteor;
    Vector3 me;
    private float meteorAdvance;
    string a;
    private float timeRemaining;
    // Use this for initialization
    void Start () {
        me = transform.position;
        meteorAdvance = PlayerPrefs.GetFloat("meteorAdvance");
        transform.position = new Vector3(me.x * Vector3.down.x, me.y * Vector3.down.y, me.z* Vector3.down.z) * meteorAdvance;
        timeRemaining = PlayerPrefs.GetFloat("globalTime");
        actualTime = timeRemaining;
        meteor = GameObject.FindGameObjectWithTag("meteor");
        a = meteor.name;
        resta = (imgPosM - imgPosm) / actualTime;
        print(a);
        print(resta);
        print(actualTime);

    }
	
	// Update is called once per frame
	void Update () {
        //timeRemaining -= Time.deltaTime;
        //StartCoroutine(al());
        transform.position += Vector3.down * Time.deltaTime*resta;
        reco = me - transform.position;
        if(reco.z == 0)
        {
            meteorAdvance = reco.y / me.y;
        }
        else if(reco.y == 0)
        {
            meteorAdvance = reco.z / me.z;
        }
        print(reco.y);
        print(reco.z);
        PlayerPrefs.DeleteKey("meteorAdvance");
        PlayerPrefs.SetFloat("meteorAdvance", meteorAdvance);
        if (timeRemaining <= 0)
        {
            SceneManager.LoadScene("BadEnd", LoadSceneMode.Single);
        }
    }
}
