using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    private Text scoreText;

    void Update()
    {
        if (ScoreManager.score >= 0 && ScoreManager.score < 30)
        {
            BulletMovement.bulletSpeed = 20f;
            Shooting.spawnTime = 2.0f;
            SpawnningEnemies.enemySpeed = 100f;
            SpawnningEnemies.spawnTime = 2.0f;

        }

        if (ScoreManager.score >= 30 && ScoreManager.score < 150)
        {
            BulletMovement.bulletSpeed = 30f;
            Shooting.spawnTime = 1.5f;
            SpawnningEnemies.enemySpeed = 150f;
            SpawnningEnemies.spawnTime = 1.5f;
        }

        else if (ScoreManager.score >= 150 && ScoreManager.score < 250)
        {
            BulletMovement.bulletSpeed = 35f;
            Shooting.spawnTime = 1.2f;
            SpawnningEnemies.enemySpeed = 160f;
            SpawnningEnemies.spawnTime = 1.2f;
        }

        else if (ScoreManager.score >= 250)
        {
            BulletMovement.bulletSpeed = 45f;
            Shooting.spawnTime = 0.7f;
            SpawnningEnemies.enemySpeed = 170f;
            SpawnningEnemies.spawnTime = 0.7f;
        }
    }
}