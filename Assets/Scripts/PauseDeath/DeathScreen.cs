using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathMenu;
    private ScoreManager SM;
    public Animator DeathButtons;

    
    void Start()
    {
        SM = GameObject.Find("PlayerManager").GetComponent<ScoreManager>();
        deathMenu.SetActive(false);   
    }

    void Update()
    {
        if (HealthManager.isDead)
            ShowMenu();
    }

    void ShowMenu()
    {
        deathMenu.SetActive(true);
        DeathButtons.SetTrigger("Play");
    }

    public void PlayAgain()
    {
        ResetVariables();
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        ResetVariables();
        SceneManager.LoadScene(0);
    }

    void ResetVariables()
    {
        SM.Start();
        HealthManager.isDead = false;
        SpawnningEnemies.canSpawn = true;
        PM.playerFire = true;
        Powerups.spawnPrefab = true;
        Shooting.enemyFire = true;
        deathMenu.SetActive(false);
    }

}
