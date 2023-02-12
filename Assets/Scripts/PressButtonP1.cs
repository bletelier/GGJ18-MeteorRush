using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PressButtonP1 : MonoBehaviour {
	PressButtonP2 scriptA;
	Text text;
	string change;
	private bool sg = true;
	private int p1;
    private float timeRemaining;
	public int win = 30;
	public void setsg(bool valor)
	{
		sg = valor;
	}
	public void setp1(int valor)
	{
		p1 = valor;
	}
	void Start () 
	{
		text = gameObject.GetComponent<Text> ();
		p1 = 0;
		change = p1.ToString ();
		text.text = change;
		scriptA = GameObject.Find ("p2").GetComponent<PressButtonP2> ();
        timeRemaining = PlayerPrefs.GetFloat("globalTime");
	}
	void Update () 
	{
        timeRemaining -= Time.deltaTime;
        if(timeRemaining <= 0)
        {
            SceneManager.LoadScene("BadEnd", LoadSceneMode.Single);
        }
		if(sg && p1 == win)
		{
			scriptA.setp2 (win);
			scriptA.setsg2 (false);
			sg = false;
            int scoreP1 = PlayerPrefs.GetInt("scoreP1");
            PlayerPrefs.DeleteKey("scoreP1");
            scoreP1 += 1;
            PlayerPrefs.SetInt("scoreP1", scoreP1);
            Debug.Log(PlayerPrefs.GetInt("scoreP1"));
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
		else if(sg)
		{
			if (Input.GetKeyDown ("p")) 
			{
				p1++;
			}
			change = p1.ToString ();
			text.text = change;
		}

	}
}
