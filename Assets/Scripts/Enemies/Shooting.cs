using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform fireTransform;
    private Rigidbody bullet_rb;
    public static bool enemyFire = true;
    public static float spawnTime = 2.0f;
    private float currentTime = 0.0f;

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= spawnTime)
        {
            Fire();
        }
    }
    public void Fire()
    {
        
        if (enemyFire)
        {
            fireTransform = transform.GetChild(0);
            GameObject bullet = Instantiate(bulletPrefab, fireTransform.position, fireTransform.rotation);
            bullet_rb = bullet.GetComponent<Rigidbody>();
            currentTime = 0.0f;
            bullet_rb.velocity = new Vector3(-3f, 0f, 0f) * 5;
        }
    }
}
