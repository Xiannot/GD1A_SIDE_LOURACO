using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jump;

    private float Move;

    public Rigidbody2D rb;
    Animator animator;

    public bool isJumping;
    public bool canMove;
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
         Move = Input.GetAxis("Horizontal");
         animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
         animator.SetFloat("xVelocity", rb.velocity.y);
         rb.velocity = new Vector2(speed * Move, rb.velocity.y);


         if(Input.GetButtonDown("Jump") && isJumping == false)
         {
            rb.AddForce(new Vector2(rb.velocity.x, jump));        
         }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }
}
