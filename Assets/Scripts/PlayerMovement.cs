using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    

    public Animator animator;
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    bool isGrounded = false;

    public FragmentManager fragmentM;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("IsJumping", true);

        }
        //This allows us to jump longer if we press the spacebar longer
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
 
        }

    

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);

        // Update the IsJumping parameter based on whether the player is grounded
        animator.SetBool("IsJumping", !IsGrounded());
    }

    private bool IsGrounded()
    {
        //If you are adding obstacles and the player cannot jump on them, THIS IS WHY!!
        //The player can only jump when they are resting on the "groundLayer"
        //Just assign the layer "Ground" to the obstacle
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fragment"))
        {
            Destroy(other.gameObject);
            fragmentM.fragmentCount++;
            animator.SetBool("IsJumping", !isGrounded);
        }
    }



}
