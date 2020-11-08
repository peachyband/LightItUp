using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float health = 20f;
    public float speed = 1.2f;
    public float activatedlamps = 0f;
    public Rigidbody2D rb;
    Vector2 movement;
    public GameObject scnctrl;
    private Animator anim;
    private bool isPaused = false;

    public void SetLamps()
    {
        activatedlamps++;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (movement.x == 0 && movement.y == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else anim.SetBool("isWalking", true);

        HealthCheck();
        WinCheck();
        PauseEnter();
        MenuEnter();
    }

    void MenuEnter()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            scnctrl.GetComponent<SceneChanger>().ChangeScene("MainMenu");
        }
    }

    void WinCheck()
    {
        if (activatedlamps >= 6)
        {
            scnctrl.GetComponent<SceneChanger>().ChangeScene("Win");
        }
    }

    void PauseEnter()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!isPaused)
            {
                Time.timeScale = 0;
                isPaused = true;
            }
            else if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
            }
        }
    }

    void HealthCheck()
    {
        if(health < 0)
        {
            scnctrl.GetComponent<SceneChanger>().ChangeScene("Lose");
        }
    }

    public void SetHealth(float hp)
    {
        health += hp;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
	
}
