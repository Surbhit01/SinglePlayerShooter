using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    //Destroys bullets when they cross the screen view
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).x <= 0.02f)
            Destroy(gameObject);
    }
}
