using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    private Slider slider;
    ScoreManager PSM;
    private Canvas canvas;
    int h = 100;
    int score;
    public GameObject explosion;

    void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        PSM = GameObject.Find("PlayerManager").GetComponent<ScoreManager>();
        setMaxHealth(h);
        Debug.Log("Health set to " + h);
    }

    public void setHealth(int health)
    {
        slider.value = health;
       // Debug.Log("Set to : " + slider.value);
        if (health < 0)
        {
            Destroy(gameObject);
            Transform body = transform.GetChild(2);
            Vector3 firePos = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
            Instantiate(explosion, firePos, Quaternion.Euler(-90f, 0f, 0f));
            //score += 20;
            ScoreManager.score += 20;
            PSM.UpdateScore(ScoreManager.score);
        }
            
    }

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}



