using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PM : MonoBehaviour
{
    public Camera cam;
    public GameObject playerPrefab;
    public GameObject canvasPrefab;
    public GameObject bulletPrefab;
    private Rigidbody player_rb;
    private GameObject canvas;
    private Animation playerMovement;
    //private Animation cameraMovement;
    private Vector3 canvasPos;
    private Vector3 touchPos;
    private float moveSpeed = 10f;
    public float bulletSpeed = 7f;
    private GameObject bullet;
    private float clampMinY;
    private float clampMaxY;
    private GameObject player;
    private float screenWidth;
    private Transform fireTransform;
    private Rigidbody bullet_rb;
    public static bool playerFire = true;
    public static bool playerSet = false;
    private Vector3 playerFinalPos = new Vector3(-16f, 1f, -5f);
    private Vector3 playerStartPos = new Vector3(-75f, 1f, -5f);

    void Start()
    {
        
        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1f);

        screenWidth = Screen.width;
        //playerStartPos = cam.ViewportToWorldPoint(new Vector3(0.1f, 0.5f, 5f));      
        player = Instantiate(playerPrefab, playerStartPos, Quaternion.Euler(180f, 0f, -90f));
        playerMovement = player.transform.GetComponent<Animation>();
        //cameraMovement = cam.transform.GetComponent<Animation>();
        playerMovement.Play();
        //cameraMovement.Play();
        player_rb = player.GetComponent<Rigidbody>();
        //transform.position = playerFinalPos;
        
        canvas = Instantiate(canvasPrefab, canvasPos, Quaternion.identity);
        //player_rb = player.GetComponent<Rigidbody>();
        clampMaxY = cam.WorldToViewportPoint(new Vector3(0f, 131f, 0f)).y;
        clampMinY = cam.WorldToViewportPoint(new Vector3(0f, -149f, 0f)).y;
        canvasPos = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.9f, 5f));
    }
    
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).position.x < screenWidth / 2)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = -5;
            touchPos.x = player.transform.position.x;

            if (touchPos.y > clampMaxY)
                touchPos.y = clampMaxY;
            else if (touchPos.y < clampMinY)
                touchPos.y = clampMinY;

            Vector3 direction = touchPos - player.transform.position;
            player_rb.velocity = new Vector3(direction.x, direction.y, direction.z) * moveSpeed;

            if (touch.phase == TouchPhase.Ended)
                player_rb.velocity = Vector3.zero;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).position.x > screenWidth / 2)
        {

            player_rb.velocity = Vector3.zero;


        }
    }

    public void OnClick()
    {
        if(playerFire)
        {
            Transform fireTransform = player.transform.GetChild(0);
            Debug.Log("Bullet");
            bullet = Instantiate(bulletPrefab, fireTransform.position, Quaternion.Euler(0f, 0f, -90f));
            bullet_rb = bullet.GetComponent<Rigidbody>();
            bullet_rb.velocity = new Vector3(2f, 0f, 0f) * bulletSpeed;
        }
        
    }
}
