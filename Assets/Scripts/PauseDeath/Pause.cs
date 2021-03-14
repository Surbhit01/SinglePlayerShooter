using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject DeathMenu;
    private ScoreManager SM;
    public Animator Reload;
    public Animator PauseScreen;
    public Button PauseButton;

    void Start()
    {
        SM = GameObject.Find("PlayerManager").GetComponent<ScoreManager>();
        PauseMenu.SetActive(false);
    }

    public void OnPause()
    {
        if (!HealthManager.isDead)
        {
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
            PauseScreen.SetTrigger("Pause");
            Debug.Log("Paused");
        }
        else
            PauseButton.interactable = false;
    }

    public void OnResume()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        Debug.Log("Resumed");
    }

    //Reloads the game scene (build no 1)
    public void OnRestart()
    {
        ResetVariables();
        /*Reload.SetTrigger("Start");
        SceneManager.LoadScene(1);*/
        Reload.SetTrigger("Start");
        SceneManager.LoadScene(1);
    }

    //Loads the main menu (build no 0)
    public void OnMainMenu()
    {
        ResetVariables();
        PauseMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }

    void ResetVariables()
    {
        SM.Start();
        Time.timeScale = 1f;
        HealthManager.isDead = false;
        SpawnningEnemies.canSpawn = true;
        PM.playerFire = true;
        Powerups.spawnPrefab = true;
        Shooting.enemyFire = true;
        //deathMenu.SetActive(false);
        
    }
}

