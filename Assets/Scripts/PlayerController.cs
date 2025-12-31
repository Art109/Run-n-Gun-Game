using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    [Header("Player Movement")]
    [SerializeField]PlayerMovement movement;
    float movementInput;

    [Header("Player Shoot")]
    [SerializeField]PlayerShoot playerShoot;


    void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        movement.Move(movementInput);
        

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>().x;
        if(context.performed)
            movement.FlipCharacter(movementInput);
        Debug.Log("Andei " + context.ReadValue<Vector2>());
    }
    public void OnJump(InputAction.CallbackContext context) 
    {
        if (context.performed)
        {
            Debug.Log("Pulei");
            movement.HandleJump();
        }

    }

    public void OnShoot(InputAction.CallbackContext context)
    {

    }


}
