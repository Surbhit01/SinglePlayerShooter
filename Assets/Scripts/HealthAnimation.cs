using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAnimation : MonoBehaviour
{
    Animator Health;
    void Start()
    {
        Health = gameObject.GetComponent<Animator>();
    }
}
