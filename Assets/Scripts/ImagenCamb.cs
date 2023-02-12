using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ImagenCamb : MonoBehaviour {

	public Image UIImagen;
	bool a1,a2,a3,a4,a5,a6;
	int cont;
    private float timeRemaining;
    // Use this for initialization
    void Start () {
		cont = 0;
		a1 = a2 = a3 = a4 = a5 = a6 = false;
		UIImagen = GameObject.Find ("1").GetComponent<Image>();
		UIImagen.sprite = Resources.Load<Sprite> ("Sprites/cocacola1");
        timeRemaining = PlayerPrefs.GetFloat("globalTime");

	}
	
	// Update is called once per frame
	void Update () {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            SceneManager.LoadScene("BadEnd", LoadSceneMode.Single);
        }
		if (a1 || Input.GetKeyDown ("w")) {
			UIImagen.sprite = Resources.Load<Sprite> ("Sprites/cocacola2");
			a1 = true;
			if(a2 || Input.GetKeyDown ("s")) {
				UIImagen.sprite = Resources.Load<Sprite> ("Sprites/cocacola3");
				a2 = true;
				if(a3 || Input.GetKeyDown ("w")) {
					UIImagen.sprite = Resources.Load<Sprite> ("Sprites/cocacola4");
					a3 = true;
					if(a4 || Input.GetKeyDown ("s")) {
						UIImagen.sprite = Resources.Load<Sprite> ("Sprites/cocacol5");
						a4 = true;
						if(a5 || Input.GetKeyDown ("a")) {
							UIImagen.sprite = Resources.Load<Sprite> ("Sprites/cocacol6");
							a5 = true;
							if(a6 || Input.GetKeyDown ("d")) {
								UIImagen.sprite = Resources.Load<Sprite> ("Sprites/cocacola7");

								print ("win p2");
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
                                }
                            }
						}
					}
				}
			}

		}
			

	}
}
