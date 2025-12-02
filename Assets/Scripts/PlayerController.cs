using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header("PlayerMovement")]
    [SerializeField]PlayerMovement movement;

    void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("Andei " + context.ReadValue<Vector2>());
    }
    public void OnJump(InputAction.CallbackContext context) 
    {
        if(context.performed)    
            Debug.Log("Pulei");
    }


}
