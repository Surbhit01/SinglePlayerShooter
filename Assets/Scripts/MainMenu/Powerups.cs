using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public GameObject shieldPrefab;
    private Rigidbody shield_rb;

    public GameObject disableEnemyBulletsPrefab;
    private Rigidbody disableEnemyBullets_rb;

    public GameObject increaseDamagePrefab;
    private Rigidbody increaseDamage_rb;

    private Vector3 SpawnPos;
    private float speed = 100f;

    public static bool spawnPrefab = true;
    

    void Start()
    {
        InvokeRepeating("SpawnPowerups", 5.0f, 10.0f);
    }

    void SpawnPowerups()
    {
        //Debug.Log("Status : " + spawnPrefab);
        if(spawnPrefab)
        {
            float posY = Random.Range(7f, -5f);
            SpawnPos = new Vector3(38f, posY, -5f);

            int prefabNo = Random.Range(0, 3);

            if (prefabNo == 0)
            {
                //SHIELD POWERUP
                GameObject shield = Instantiate(shieldPrefab, SpawnPos, Quaternion.Euler(0f, 0f, 45f));
                shield_rb = shield.GetComponent<Rigidbody>();
                shield_rb.AddForce(new Vector3(-5f, 0f, 0f) * speed);
            }

            else if (prefabNo == 1)
            {
                //ENEMY BULLET DISABLE POWERUP
                GameObject disableEnemyBullets = Instantiate(disableEnemyBulletsPrefab, SpawnPos, Quaternion.Euler(0f, 0f, 45f));
                disableEnemyBullets_rb = disableEnemyBullets.GetComponent<Rigidbody>();
                disableEnemyBullets_rb.AddForce(new Vector3(-5f, 0f, 0f) * speed);
            }

            else
            {
                //INCREASE DAMAGE POWERUP
                GameObject increaseDamage = Instantiate(increaseDamagePrefab, SpawnPos, Quaternion.Euler(0f, 0f, 45f));
                increaseDamage_rb = increaseDamage.GetComponent<Rigidbody>();
                increaseDamage_rb.AddForce(new Vector3(-5f, 0f, 0f) * speed);
            }
        }
    }
}
