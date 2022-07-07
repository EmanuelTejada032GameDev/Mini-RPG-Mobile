using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRenderer : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 movementInput = value.ReadValue<Vector2>();
        if (movementInput.x > 0f && PlayerIsLookingLeft())
        {
            _spriteRenderer.flipX = false;    
        }else if(movementInput.x < 0f && !PlayerIsLookingLeft())
        {
            _spriteRenderer.flipX = true;
        }

    }
    private bool PlayerIsLookingLeft()
    {
        return _spriteRenderer.flipX;
    }
}
