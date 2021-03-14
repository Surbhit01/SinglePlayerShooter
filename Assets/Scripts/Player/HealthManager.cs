using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider slider;
    public static bool isDead = false;
    int h = 100;
    Animator Health;
    //Animator Canvas;
    void Awake()
    {
        Health = gameObject.GetComponent<Animator>();
        setMaxHealth(h);
    }

    public void setHealth(int health)
    {
        slider.value = health;
        if (health <= 0)
        {
            Health.SetTrigger("Play");
            isDead = true;
        }
    }

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    
    
}
