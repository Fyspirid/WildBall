using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Vector3 inTheObj;
    public GameObject cube;
    public GameObject sphere;
    public GameObject capsul;
    public GameObject cylinder;
    public int numberCreate;
    
    void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        for (int i = 0; i < numberCreate; i++)
        {
            Vector3 pos = new Vector3(Random.Range(8, -1), Random.Range(-20, 38), Random.Range(-65, -55));
            Instantiate(cube, pos, Quaternion.identity);

            Vector3 pos2 = new Vector3(Random.Range(8, -1), Random.Range(-20, 38), Random.Range(-65, -55));
            Instantiate(sphere, pos2, Quaternion.identity);

            Vector3 pos3 = new Vector3(Random.Range(8, -1), Random.Range(-20, 38), Random.Range(-65, -55));
            Instantiate(capsul, pos3, Quaternion.identity);

            Vector3 pos4 = new Vector3(Random.Range(8, -1), Random.Range(-20, 38), Random.Range(-65, -55));
            Instantiate(cylinder, pos4, Quaternion.identity);
        }
    }
}
