using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bola : MonoBehaviour {
	public int speedX;
	public int speedY;

 	public float speed;
    private float timeRemaining;

	// Use this for initialization
	void Start () {


        timeRemaining = PlayerPrefs.GetFloat("globalTime");
		if (speedX == 0) {
			speedX = 1;
		} else {
			speedX = -1;
		}


		if (speedY == 0) {
			speedY = 1;
		} else {
			speedY = -1;
		}

		GetComponent<Rigidbody>().velocity = new Vector3(speed * speedX, speed * speedY, 0); 
	}
	
	// Update is called once per frame
	void Update () {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            SceneManager.LoadScene("BadEnd", LoadSceneMode.Single);
        }
    }
		
	void OnCollisionEnter(Collision objeto){
		if (objeto.collider.tag == "arco1") {
			//pierde player 1
			Debug.Log("Pierde player 1");
            UpdateScore("scoreP2");
            ChangeScene();
        }
		if (objeto.collider.tag == "arco2") {
			//pierde player 2
			Debug.Log("Pierde player 2");
            UpdateScore("scoreP1");
            ChangeScene();

        }

    }

    void ChangeScene()
    {
        string[] scenesPath = new string[10];
        scenesPath[0] = "Central";
        scenesPath[1] = "TestingGGJ2018MN1";
        scenesPath[2] = "TestingGGJ2018MN2";
        scenesPath[3] = "TestingGGJ2018MN3";
        scenesPath[4] = "TestingGGJ2018MN4";
        scenesPath[5] = "TestingGG2018MN5";
        scenesPath[6] = "Drink";
        scenesPath[7] = "Smash";
        scenesPath[8] = "ScapeTheBomb";
        scenesPath[9] = "pingpong";
        int choose = Random.Range(1, 9);
        while (choose == PlayerPrefs.GetInt("levelUsed"))
        {
            choose = Random.Range(1, 9);
        }
        PlayerPrefs.DeleteKey("levelUsed");
        PlayerPrefs.SetInt("levelUsed", choose);
        PlayerPrefs.DeleteKey("globalTime");
        PlayerPrefs.SetFloat("globalTime", timeRemaining);
        SceneManager.LoadScene(scenesPath[choose], LoadSceneMode.Single);
    }

    void UpdateScore(string key)
    {
        int score = PlayerPrefs.GetInt(key);
        PlayerPrefs.DeleteKey(key);
        score += 1;
        PlayerPrefs.SetInt(key, score);
        Debug.Log(PlayerPrefs.GetInt(key));
    }

	/*void OnTriggerEnter(Collider other) {
		Debug.Log (other.gameObject.tag);
		print(other.gameObject.tag);
		if (other.gameObject.tag==("arco1")) {
			Debug.Log("Pierde player 1");
		}
		else if (other.gameObject.tag==("arco2")) {
			Debug.Log("Pierde player 2");
		}
	}*/
}
