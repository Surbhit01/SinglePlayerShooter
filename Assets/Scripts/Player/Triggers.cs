using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    HealthManager PHM;
    ScoreManager PSM;
    private SlowMotion SM;
    private int health = 100;
    private bool enemyFire = false;
    public static bool enemySpawn;
    public static bool playerFire;
    public static bool powerupSpawn;
    public GameObject fire;
    private int score;
    public bool ShieldOff = true;

    void Start()
    {
        PHM = GameObject.Find("HealthScoreCanvas(Clone)").GetComponent<HealthManager>();
    }

    private void OnTriggerEnter(Collider col)
    {
        //Player hit by enemy bullet
        if (col.gameObject.name == "Enemy Bullet(Clone)")
        {
            Destroy(col.gameObject);

            if (ShieldOff)
            {
                health -= 5;
                //Debug.Log("Calling..");
                //PHM.check();
                PHM.setHealth(health);

                //Stops player and enemies from firing when player is dead
                if (health <= 0)
                {
                    //Fire explosion
                    fireExplosion();

                    //Deactivate player @ health = 0
                    gameObject.SetActive(false);
                    
                    //Disable enemy firing
                    enemyFire = false;
                    Shooting.enemyFire = enemyFire;

                    //Disables enemy and powerups spawning
                    enemySpawn = false;
                    powerupSpawn = false;
                   // Debug.Log("Setting enemies to : " + enemySpawn);
                    SpawnningEnemies.canSpawn = enemySpawn;
                    
                    //Debug.Log("Setting powerup to : " + powerupSpawn);
                    Powerups.spawnPrefab = powerupSpawn;

                    ////Disable enemy firing 
                    playerFire = false;
                    PM.playerFire = playerFire;

                    
                }

                
            }

        }

        //Player and enemy hit each other
        if (col.gameObject.name == "Enemy(Clone)")
        {
            //Instantiate fire prefab
            fireExplosion();

            gameObject.SetActive(false); //Deactivates player
            enemyFire = false;
            playerFire = false;
            powerupSpawn = false;
            Shooting.enemyFire = enemyFire;//Enemies stop firing
            PM.playerFire = playerFire;//Player stop firing
            Powerups.spawnPrefab = powerupSpawn;//Powerups stop spawning
            health = 0;
            SpawnningEnemies.canSpawn = false;
            PHM.setHealth(health);
        }

        //SHIELD POWERUP
        if (col.gameObject.name == "Shield(Clone)")
        {
            //Debug.Log(col.gameObject);
            Destroy(col.gameObject);
            ShieldOff = false;
            StartCoroutine(SwitchShield());
        }

        //DISABLE ENEMY BULLETS POWERUP
        if (col.gameObject.name == "DisableEnemyBullets(Clone)")
        {
            Destroy(col.gameObject);
            StartCoroutine(SwitchBullets());
        }

        //INCREASE PLAYER DAMAGE POWERUP
       if (col.gameObject.name == "IncreaseDamage(Clone)")
        {
            Destroy(col.gameObject);
            StartCoroutine(IncreaseDamage());
        }

    }

    //Protects the player from damage for 5 seconds
    IEnumerator SwitchShield()
    {
        ShieldOff = false;

        yield return new WaitForSeconds(5);

        ShieldOff = true;
    }

    //Disables the enemies from firing for 5 seconds
    IEnumerator SwitchBullets()
    {
        enemyFire = Shooting.enemyFire;
        enemyFire = !enemyFire;
        Shooting.enemyFire = enemyFire;

        yield return new WaitForSeconds(5);

        enemyFire = true;
        Shooting.enemyFire = enemyFire;
        Debug.Log("Status after 5 sec : " + enemyFire);
    }

    //Increases the damage done by player to 25 for 5 seconds
    IEnumerator IncreaseDamage()
    {
        int damage = 25;
        EnemyTriggers.damage = damage;

        yield return new WaitForSeconds(5);

        damage = 20;
        EnemyTriggers.damage = damage;
    }

    void fireExplosion()
    {
        //Instantiate fire prefab
        Vector3 firePos = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
        Instantiate(fire, firePos, Quaternion.Euler(-90f, 0f, 0f));
    }
}
    
