using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int activatedlamps = 0;
    public float health = 10;
    public float speed = 1.2f;
    public Rigidbody2D rb;
    Vector2 movement;
    public GameObject scnctrl;
    
    private Animator anim;

    public void SetLamp(){ Debug.Log("+1"); activatedlamps += 1;}

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
        if(activatedlamps >= 6)
        {
            scnctrl.GetComponent<SceneChanger>().ChangeScene("Win");
        }
    }

    public void SetHealth(float hp)
    {
        health += hp;
    }

    void HealthCheck()
    {
        if (health < 0)
        {
            scnctrl.GetComponent<SceneChanger>().ChangeScene("Lose");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
	
}
