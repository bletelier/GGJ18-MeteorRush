using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsMN5 : MonoBehaviour {

    public GameObject spawnObject;
    public float limitObjects;
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    IEnumerator SpawnsObj()
    {
        yield return new WaitForSeconds(4);
        while(limitObjects > 0)
        {
            yield return new WaitForSeconds(0.25f);
            Vector3 position = new Vector3(Random.Range(xMin, xMax), 0.0f, Random.Range(zMin,zMax));
            Quaternion theRotate = Quaternion.identity;
            Instantiate(spawnObject, position, theRotate);
            limitObjects -= 1;

        }
    }

    private void Start()
    {
        StartCoroutine(SpawnsObj());
    }
}
