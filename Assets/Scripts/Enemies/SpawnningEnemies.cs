using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnningEnemies : MonoBehaviour
{
    public static float enemySpeed = 200f;
    public GameObject enemyPrefab;
    public Camera cam;
    public static float spawnTime = 2f;
    public static bool canSpawn = true;

    private GameObject enemy;
    private Transform fireTransform;
    private Rigidbody enemy_rb;
    private Vector3 FirePos;
    private Vector3 SpawnPos;
    private float currentTime = 0.0f;


    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= spawnTime)
        {
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        if (canSpawn && !HealthManager.isDead)
        {
            float posY = Random.Range(7f, -5f);
            SpawnPos = new Vector3(38f, posY, -5f);
            enemy = Instantiate(enemyPrefab, SpawnPos, Quaternion.Euler(0f, -180f, -90f));
            enemy_rb = enemy.GetComponent<Rigidbody>();
            enemy_rb.AddForce(new Vector3(-4f, 0f, 0f) * enemySpeed);
            currentTime = 0;
        }
    }

    
}
