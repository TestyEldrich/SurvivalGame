using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private bool isHoldingShift;

    private void Awake() {
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
    }

    public Vector2 GetMovementVector() {
        Vector2 direction = inputActions.Player.Move.ReadValue<Vector2>();

        return direction;
    }

    public bool GetIsHoldingShift() {
        return isHoldingShift;
    }

    public void IsHoldingShift(InputAction.CallbackContext context) {
        isHoldingShift = (!context.started || context.performed) ^ context.canceled;
    }
}