using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector3 mousePosition;
    public GameObject ball;
    public Transform ballTransform;
    private float timer;
    public float timeBetween = 0.3f;
    private bool canFire = true;
    // Start is called before the first frame update
    void Update()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePosition - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer> timeBetween)
            {
                canFire = true;
                timer = 0;
            }
        }
        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(ball, ballTransform.position, Quaternion.identity);
        }
    }
}
