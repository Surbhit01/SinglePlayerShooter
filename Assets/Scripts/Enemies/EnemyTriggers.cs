using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTriggers : MonoBehaviour
{
    private EnemyHealthManager EM;
    ScoreManager PSM;
    private int health = 100;
    public static int damage = 20;

    void Awake()
    {
        EM = transform.GetComponent<EnemyHealthManager>();
        //HM = GameObject.Find("HealthScoreCanvas(Clone)").GetComponent<HealthManager>();
        PSM = GameObject.Find("PlayerManager").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider col)
    {
        //Player bullet hits enemy
        if (col.gameObject.name == "Player Bullet(Clone)")
        {
            Destroy(col.gameObject);
            health -= damage;
            Debug.Log(health);
            ScoreManager.score += 10;
            EM.setHealth(health);
            PSM.UpdateScore(ScoreManager.score);
        }

        //Player and enemy hit each other
        if (col.gameObject.name == "Player(Clone)")
        {
            Destroy(gameObject);
            health = 0;
            EM.setHealth(health);


        }
    }
}
