using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    
    [SerializeField] float knockBack;

    Rigidbody2D rb;
    Animator a;
    Vector2 directionalInput;

    bool isGrounded;
    bool doubleJump;

    bool isAlive;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        a = GetComponent<Animator>();
        
        isAlive = true;

        a.SetBool("isAlive", true);
    }

    void Update()
    {
        if (!isAlive) { return; }
        if (FindAnyObjectByType<FinishFlag>().GetIsHatAnimationBool()) { return; }

        Movement();
        FlipDirection();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            doubleJump = true;
        }
    }
    void OnMove(InputValue value)
    {
        directionalInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        if(!isAlive) { return; }
        if (FindAnyObjectByType<FinishFlag>().GetIsHatAnimationBool()) { return; }

        if (value.isPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(moveSpeed * directionalInput.x, jumpForce);          
            isGrounded = false;
        }
        else if (value.isPressed && doubleJump)
        {
            rb.linearVelocity = new Vector2(moveSpeed * directionalInput.x, jumpForce);
            doubleJump = false;
        }
    }
    void Movement()
    {
        Vector2 playerVelocity = new Vector2(moveSpeed * directionalInput.x, rb.linearVelocity.y);

        rb.linearVelocity = playerVelocity;
    }
    void FlipDirection()
    {
        bool horizontalMovement = Mathf.Abs(directionalInput.x) > Mathf.Epsilon;

        if (horizontalMovement)
        { 
            transform.localScale = new Vector2(Mathf.Sign(directionalInput.x), 1f);
        }
    }
    public void Die()
    {
        rb.linearVelocity = new Vector2(0f, knockBack);
        isAlive = false;
        a.SetBool("isAlive", false);
        FindAnyObjectByType<LevelManager>().PlayerDeath();
    }
}
