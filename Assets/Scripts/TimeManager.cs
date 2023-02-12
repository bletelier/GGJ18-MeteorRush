using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {

    private float timeRemaining;

    private void Start()
    {
        timeRemaining = PlayerPrefs.GetFloat("globalTime");
        PlayerPrefs.DeleteKey("globalTime");
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;    
        if(timeRemaining == 0)
        {
            SceneManager.LoadScene("End", LoadSceneMode.Single);
        }
    }

}
