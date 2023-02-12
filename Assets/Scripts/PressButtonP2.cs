using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressButtonP2 : MonoBehaviour {
	PressButtonP1 scriptA;
	Text text;
	string change;
	private bool sg2 = true;
	private int p2;
    private float timeRemaining;
	public int win = 30;
	public void setsg2(bool valor)
	{
		sg2 = valor;
	}
	public void setp2(int valor)
	{
		p2 = valor;
	}
	void Start () 
	{
		text = gameObject.GetComponent<Text> ();
		p2 = 0;
		change = p2.ToString ();
		text.text = change;
		scriptA = GameObject.Find ("p1").GetComponent<PressButtonP1> ();
        timeRemaining = PlayerPrefs.GetFloat("globalTime");
	}
	void Update () 
	{
        timeRemaining -= Time.deltaTime;
        if(timeRemaining <= 0)
        {
            SceneManager.LoadScene("BadEnd", LoadSceneMode.Single);
        }
		if(sg2 && p2 == win)
		{
			scriptA.setp1 (win);
			scriptA.setsg (false);
			sg2 = false;
            int scoreP2 = PlayerPrefs.GetInt("scoreP2");
            PlayerPrefs.DeleteKey("scoreP2");
            scoreP2 += 1;
            PlayerPrefs.SetInt("scoreP2", scoreP2);
            Debug.Log(PlayerPrefs.GetInt("scoreP2"));
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
            };
        }
		else if(sg2)
		{
			if (Input.GetKeyDown ("q")) 
			{
				p2++;
			}
			change = p2.ToString ();
			text.text = change;
		}


	}
}
