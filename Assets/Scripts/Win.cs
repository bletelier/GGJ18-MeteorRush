using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {

	private bool win;
    public string tagHouse;
    private float timeRemaining;

	void setwin(bool gano)
	{
		win = gano;
	}

	void Start () {
		win = false;
        timeRemaining = PlayerPrefs.GetFloat("globalTime");
    }
	
	void Update () 
	{
        timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0) {
            SceneManager.LoadScene("BadEnd", LoadSceneMode.Single);
        }	
	}
	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
        if (tagHouse.Equals("uno"))
        {
            UpdateScore("scoreP1");
        }
        else
        {
            UpdateScore("scoreP2");
        }
        if (PlayerPrefs.GetInt("scoreP1") < 10 && PlayerPrefs.GetInt("scoreP2") < 10)
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
        else
        {
            SceneManager.LoadScene("End", LoadSceneMode.Single);
        }
    }

    void UpdateScore(string key)
    {
        int score = PlayerPrefs.GetInt(key);
        PlayerPrefs.DeleteKey(key);
        score += 1;
        PlayerPrefs.SetInt(key, score);
        Debug.Log(PlayerPrefs.GetInt(key));
    }

}
