using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShots : MonoBehaviour {

    public GameObject hazard;
    public float StartWait;
    public float spawnWait;
    public float waveWait;
    public Vector2 spawnValues;
    public int hazards;

	void Start () {
        StartCoroutine(SpawnWaves());
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(StartWait);
        while (true)
        {
            for(int count = 0; count< hazards; count++)
            {
                Vector3 shotPosition = new Vector3(Random.Range(7.12f, 25.88f), 0.0f, spawnValues.y);
                Vector3 shotPosition2 = new Vector3(Random.Range(-23.4f, -4.57f), 0.0f, spawnValues.y);
                Quaternion theRotation = Quaternion.identity;
                Instantiate(hazard, shotPosition, theRotation);
                Instantiate(hazard, shotPosition2, theRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
	
	
}
