using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Transform")]
    [SerializeField]Transform playerTransform;

    [Header("Rigidbody")]
    [SerializeField]Rigidbody2D rb;

    [Header("Movement Params")]
    [SerializeField] float moveSpeed;
    public float PlayerDirection { get; private set; } = 1f;

    [Header("Jump Params")]
    [SerializeField] float jumpForce;

    [Header("GroundCheck Param")]
    [SerializeField] Transform groundCheckPos;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float detectionRange;



    public void Move(float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y) ;
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
        if (GroundCheck())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
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
