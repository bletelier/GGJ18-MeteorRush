using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondGameManager : MonoBehaviour
{

    private AssetBundle myScenes;
    private string[] scenesPath;
    private static int scoreP1 = 0;
    private static int scoreP2 = 0;
    private static int meteorAdvance = 0;

    public void SceneChoose()
    {
        scenesPath = new string[10];
        scenesPath[0] = "Central";
        scenesPath[1] = "TestingGGJ2018MN1";
        scenesPath[2] = "TestingGGJ2018MN2";
        scenesPath[3] = "TestingGGJ2018MN3";
        int choose = Random.Range(1, scenesPath.Length - 1);
        SceneManager.LoadScene(scenesPath[choose], LoadSceneMode.Single);

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
}

