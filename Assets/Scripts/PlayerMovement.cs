using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;    
    [SerializeField] float knockBack;
    [SerializeField] float wallClimbGravity = 0f;
    [SerializeField] float normalGravity = 6f;

    Rigidbody2D rb;
    Animator a;
    CapsuleCollider2D cc;
    BoxCollider2D bc;
    Vector2 directionalInput;

    [SerializeField] bool isGrounded;
    [SerializeField] bool doubleJump;
    bool isAlive;

    bool isOnOrangePlatform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        bc = GetComponent<BoxCollider2D>();
        a = GetComponent<Animator>();

        isAlive = true;
        isOnOrangePlatform = false;

        a.SetBool("isAlive", true);
    }

    void Update()
    {
        if (!isAlive) { return; }
        if (FindAnyObjectByType<FinishFlag>()) 
        {
            FindAnyObjectByType<FinishFlag>().GetIsHatAnimationBool();
            return; 
        }
        else if(FindAnyObjectByType<FinishFlagFinalLevel>().GetIsDialogueStartedBool()) { return; }

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

        if (bc.IsTouchingLayers(LayerMask.GetMask("Orange")))
        {
            isOnOrangePlatform = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!bc.IsTouchingLayers(LayerMask.GetMask("Orange")))
        {
            isOnOrangePlatform = false;
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
        if (!isOnOrangePlatform)
        {
            rb.linearVelocity = new Vector2(moveSpeed * directionalInput.x, rb.linearVelocity.y);
            rb.gravityScale = normalGravity;
        }
        else if(isOnOrangePlatform)
        {
            rb.gravityScale = wallClimbGravity;
            rb.linearVelocity = new Vector2(moveSpeed * directionalInput.x, moveSpeed * directionalInput.y);
        }
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

    public Rigidbody2D GetPlayerRigidbody() { return rb; }
    public float GetPlayerMoveSpeed() { return moveSpeed; }
}
