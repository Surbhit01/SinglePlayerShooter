using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFlames : MonoBehaviour
{
    public GameObject[] crossFlame;
    private float currentTime = 0.0f;
    private float spawnTime = 10.0f;
    //public static bool canFlame = true;

    void Update()
    {           
            currentTime += Time.deltaTime;

            if (currentTime >= spawnTime)
            {
                int i = (int)Random.Range(0, 4);
                Instantiate(crossFlame[i], crossFlame[i].transform.position, crossFlame[i].transform.rotation);
                currentTime = 0.0f;
            }     
    }
}
