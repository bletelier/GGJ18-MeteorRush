using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private AssetBundle myScenes;
    private string[] scenesPath;
    private static int scoreP1 = 0;
    private static int scoreP2 = 0;
    private static float meteorAdvance = 0;

    void SetScoreP1()
    {
        scoreP1 += 1;
    }

    void SetScoreP2()
    {
        scoreP2 += 1;
    }

    void SetGlobals()
    {
        PlayerPrefs.SetInt("ScoreP1", scoreP1);
        PlayerPrefs.SetInt("ScoreP2", scoreP2);
        Debug.Log(PlayerPrefs.GetInt("scoreP1"));
        Debug.Log(PlayerPrefs.GetInt("scoreP1"));
        PlayerPrefs.SetFloat("MeteorAdvance", meteorAdvance);
        PlayerPrefs.SetFloat("globalTime", 150);
    }

    void SceneChoose()
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
        PlayerPrefs.SetInt("levelUsed", choose);
        SceneManager.LoadScene(scenesPath[choose], LoadSceneMode.Single);

    }

    IEnumerator Begin()
    {
        yield return new WaitForSeconds(4);
        SceneChoose();
    }

    void Start()
    {
        PlayerPrefs.DeleteAll();
        SetGlobals();
        StartCoroutine(Begin());
    }

    void VerifiedScore(int score)
    {
        if (score < 10)
        {
            return;
        }
        else
        {
            SceneManager.LoadScene("End", LoadSceneMode.Single);
        }
    }

    void Update()
    {
        
    }
}

