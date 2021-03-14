using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public static float bulletSpeed = 20f;
    private Transform player;
    private Vector3 targetPos;

    /*void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        targetPos.x = player.position.x - 4.0f;
        targetPos.y = player.position.y;
        targetPos.z = player.position.z;
    }*/

    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, targetPos, bulletSpeed * Time.deltaTime);
        if (Camera.main.WorldToViewportPoint(transform.position).x <=0.02f)
            Destroy(gameObject);
    }
}
