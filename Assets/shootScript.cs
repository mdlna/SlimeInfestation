using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    public GameObject magicBall;
    private Vector2 mousePosition;
    public Camera sceneCamera;
    public Transform firePoint;
    public float fireForce;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject ball = Instantiate(magicBall, firePoint.position, firePoint.rotation);
        ball.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
