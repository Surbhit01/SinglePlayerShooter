using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text scoreText;
    public static int score;
    
    public void Start()
    {
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(1);
        score = 0;
        Transform textHolder = GameObject.Find("HealthScoreCanvas(Clone)").transform.GetChild(1);
        scoreText = textHolder.GetComponent<Text>();
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "SCORE: " + score.ToString();        
    }
}
