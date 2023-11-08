using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    // Start is called before the first frame update
    float horizontalMove = 0f;
    public float runSpeed = 60f;
    bool jump = false;

    [SerializeField] private AudioSource jumpSfx;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject canvasStart;
    // Update is called once per frame

    void Start()
    {
        Time.timeScale = 0;
        canvasStart.SetActive(true);
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;
            canvasStart.SetActive(false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            jumpSfx.Play();
            jump = true;
        }
        if (Input.GetKeyDown("escape"))
        {
            pauseGame();
        }
    }

    void pauseGame()
    {
        Time.timeScale = 0;
        canvas.SetActive(true);
    }
    public void resumeGame()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="portal")
        {
            SceneManager.LoadScene(2);
        }
    }
}
