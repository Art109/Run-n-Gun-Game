using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    [Header("Player Movement")]
    [SerializeField]PlayerMovement movement;
    float moveInput;
    bool jumpPressed;

    [Header("Player Shoot")]
    [SerializeField]PlayerShoot playerShoot;


    void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        movement.SetMovementInput(moveInput);

        if (jumpPressed)
        {
            movement.BufferJumpInput();
            jumpPressed = false;
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().x;

        if(context.performed)
            movement.FlipCharacter(moveInput);
        
    }
    public void OnJump(InputAction.CallbackContext context) 
    {
        if (context.performed)
        {
            jumpPressed = true;
        }

    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            Debug.Log("Atirei");
            playerShoot.Shoot(new Vector2(movement.PlayerDirection,0));
        }

    }


}
