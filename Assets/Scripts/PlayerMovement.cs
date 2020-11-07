using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.2f;
    public Rigidbody2D rb;
    Vector2 movement;

    private Animator anim;

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
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
	
}
