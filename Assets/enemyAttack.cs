using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class enemyAttack : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject turn;
    public float speed;
    private Rigidbody2D rb;
    private Transform currentPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
        turn = GameObject.Find("TURN");
        rb = GetComponent<Rigidbody2D>();
        currentPoint = turn.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if ( currentPoint == turn.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision.gameObject.tag " + collision.gameObject.tag);
        Debug.Log("gameObject.tag " + gameObject.tag);
        if (collision.gameObject.tag == "CASA")
        {
            SceneManager.LoadScene(2);
        }
    }
}
