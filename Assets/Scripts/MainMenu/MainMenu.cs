using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    private GameObject DeathMenu;
 
    public void StartGame()
    {
        Game();  
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Game()
    {
        StartCoroutine("SceneTransition");
    }

    IEnumerator SceneTransition()
    {
        transition.SetTrigger("Start");

        Debug.Log("Starting");
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("GameScene");
    }
}
