using Unity.VisualScripting;
using UnityEngine;

public class Bully : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float jumpForce = 2f;
    [SerializeField] LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool shouldJump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        //Is Grounded?
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        //Player Direction
        float direction = Mathf.Sign(player.position.x - transform.position.x);
        
        //Player above detection
        bool isPlayerAbove = Physics2D.Raycast(transform.position, Vector2.up, 6f, 1 << player.gameObject.layer);

        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(moveSpeed * direction, rb.linearVelocity.y);

            //If theres a gap ahead && no ground infront
            //else if theres a player above and platform above

            //If ground
            RaycastHit2D groundInFront = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 2f, groundLayer);

            //If gap
            RaycastHit2D gapAhead = Physics2D.Raycast(transform.position + new Vector3(direction, 0, 0), Vector2.down, 2f, groundLayer);

            //If platform above
            RaycastHit2D platformAbove = Physics2D.Raycast(transform.position, Vector2.up, 6f, groundLayer);

            if (!groundInFront.collider && !gapAhead.collider)
            {
                shouldJump = true;
            }
            if (!groundInFront.collider && platformAbove.collider)
            {
                shouldJump = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded && shouldJump)
        {
            shouldJump = false;

            Vector2 direction = (player.position - transform.position).normalized;

            Vector2 jumpDirection = direction * jumpForce;

            rb.AddForce(new Vector2(jumpDirection.x, jumpForce), ForceMode2D.Impulse);
        }
    }
}
