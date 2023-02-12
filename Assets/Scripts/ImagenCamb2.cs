using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ImagenCamb2 : MonoBehaviour {

	public Image UIImagen;
	bool a1,a2,a3,a4,a5,a6;
    private float timeRemaining;
	int cont;
	// Use this for initialization
	void Start () {
		cont = 0;
		a1 = a2 = a3 = a4 = a5 = a6 = false;
		UIImagen = GameObject.Find ("2").GetComponent<Image>();
		UIImagen.sprite = Resources.Load<Sprite> ("Sprites/vodka1");
        timeRemaining = PlayerPrefs.GetFloat("globalTime");

	}

	// Update is called once per frame
	void Update () {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            SceneManager.LoadScene("BadEnd", LoadSceneMode.Single);
        }
		if (a1 || Input.GetKeyDown (KeyCode.UpArrow)) {
			UIImagen.sprite = Resources.Load<Sprite> ("Sprites/vodka2");
			a1 = true;
			if(a2 || Input.GetKeyDown (KeyCode.DownArrow)) {
				UIImagen.sprite = Resources.Load<Sprite> ("Sprites/vodka3");
				a2 = true;
				if(a3 || Input.GetKeyDown (KeyCode.UpArrow)) {
					UIImagen.sprite = Resources.Load<Sprite> ("Sprites/vodka4");
					a3 = true;
					if(a4 || Input.GetKeyDown (KeyCode.DownArrow)) {
						UIImagen.sprite = Resources.Load<Sprite> ("Sprites/vodka5");
						a4 = true;
						if(a5 || Input.GetKeyDown (KeyCode.LeftArrow)) {
							UIImagen.sprite = Resources.Load<Sprite> ("Sprites/vodka6");
							a5 = true;
							if(a6 || Input.GetKeyDown (KeyCode.RightArrow)) {
								UIImagen.sprite = Resources.Load<Sprite> ("Sprites/vodka7");

								print ("win p2");
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
                                    while(choose == PlayerPrefs.GetInt("levelUsed"))
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
						}
					}
				}
			}

		}


	}
}
