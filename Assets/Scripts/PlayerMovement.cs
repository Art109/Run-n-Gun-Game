using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerController playerController;
    PlayerInputHandler inputHandler;

    [Header("Movement Speed")]
    [SerializeField] float moveSpeed;

    [Header("Jump Params")]
    [SerializeField] float jumpForce;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        inputHandler = PlayerInputHandler.Instance;
    }



    private void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {

    }

}
