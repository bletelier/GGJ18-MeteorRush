using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsMN4 : MonoBehaviour {

    public GameObject cube;
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    private bool alive = false;
    private int countSpawns = 5;

	void Start () {
        StartCoroutine(SpawnObjects());
	}
	
	
	IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            if (countSpawns > 0 && !alive)
            {
                Vector3 position = new Vector3(Random.Range(xMin, xMax), 0.0f, Random.Range(zMin, zMax));
                Quaternion theRotate = Quaternion.identity;
                Instantiate(cube, position, theRotate);
                countSpawns--;
                //alive = false;
                yield return new WaitForSeconds(4);
            }
            if (countSpawns == 0) break;
        }
    }
}
