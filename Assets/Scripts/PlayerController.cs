using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    [Header("PlayerMovement")]
    [SerializeField]PlayerMovement movement;
    float movementInput;

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
        if(context.performed)    
            Debug.Log("Pulei");
    }


}
