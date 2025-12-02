using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Rigidbody")]
    [SerializeField]Rigidbody2D rb;

    [Header("Movement Speed")]
    [SerializeField] float moveSpeed;

    [Header("Jump Params")]
    [SerializeField] float jumpForce;



    public void Move(Vector2 vector)
    {
        rb.velocity = vector;
    }
    



}
