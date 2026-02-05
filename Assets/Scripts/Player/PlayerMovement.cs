using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Transform")]
    [SerializeField]Transform playerTransform;

    [Header("Rigidbody")]
    [SerializeField]Rigidbody2D rb;

    [Header("Movement Params")]
    [SerializeField] float moveSpeed;
    float moveInput;
    public float PlayerDirection { get; private set; } = 1f;

    [Header("Jump Params")]
    [SerializeField] float jumpForce;

    [Header("Jump Feel")]
    [SerializeField] float coyoteTime = 0.15f;
    [SerializeField] float jumpBufferTime = 0.15f;

    float coyoteTimeCounter;
    float jumpBufferCounter;


    [Header("GroundCheck Param")]
    [SerializeField] Transform groundCheckPos;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float detectionRange;


    private void FixedUpdate()
    {
        ApplyMovement();
        HandleJump();
    }

    private void Update()
    {
        UpdateCoyoteTime();
        UpdateJumpBuffer();
    }

    public void SetMovementInput(float input)
    {
        moveInput = input;
    }
    public void ApplyMovement()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y) ;
    }
    
    public void FlipCharacter(float direction)
    {
        Debug.Log("Direction: " +  direction); 
        Debug.Log("Player Direction 1: " + PlayerDirection);
        if (direction != PlayerDirection)
        {
            Vector3 scale = playerTransform.localScale;
            scale.x *= -1;
            playerTransform.localScale = scale;

            PlayerDirection *= -1;
            Debug.Log("Player Direction 2: " + PlayerDirection);
        }
            
    }

    public void HandleJump() 
    {
        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            // Consome os buffers
            jumpBufferCounter = 0;
            coyoteTimeCounter = 0;
        }
    }

    public void BufferJumpInput()
    {
        jumpBufferCounter = jumpBufferTime;
    }

    void UpdateJumpBuffer()
    {
        jumpBufferCounter -= Time.deltaTime;
    }

    void UpdateCoyoteTime()
    {
        if (GroundCheck())
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;
    }


    public bool GroundCheck()
    {
        if(Physics2D.Raycast(groundCheckPos.position , Vector2.down, detectionRange,groundLayer )
            || Physics2D.Raycast(groundCheckPos.position + new Vector3(10, 0 , 0), Vector2.down, detectionRange, groundLayer)
            || Physics2D.Raycast(groundCheckPos.position + new Vector3(-10, 0, 0), Vector2.down, detectionRange, groundLayer))
        {
            return true;
        }

        return false;
        
    }


}
