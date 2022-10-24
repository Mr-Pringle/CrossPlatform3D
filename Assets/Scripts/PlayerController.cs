using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Camera playerCamera;

    

    PlayerInput input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        Debug.Log(context.action.ReadValue<Vector2>());
    }

    public void Look(InputAction.CallbackContext context)
    {
        Debug.Log(context.action.ReadValue<Vector2>());
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.action.WasPressedThisFrame())
        {
            Debug.Log("Fire Pressed");
        }

        if (context.action.WasReleasedThisFrame())
        {
            Debug.Log("Fire was released");
        }
    }
}
