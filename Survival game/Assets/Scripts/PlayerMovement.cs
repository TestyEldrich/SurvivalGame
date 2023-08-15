using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float playerSpeed = 8f;
    [SerializeField] private GameInput gameInput;
    private bool isFacingLeft = false;
    private bool isWalking;
    private bool isRunning;
    private void Update(){
        Vector2 direction = gameInput.GetMovementVector();

        if (direction.x > 0 && isFacingLeft) {
            isFacingLeft = false;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("right");
        }else if (direction.x < 0 && !isFacingLeft) {
            isFacingLeft = true;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            Debug.Log("left");
        }

        direction = direction.normalized;

        Vector3 dir3 = new(direction.x, 0, direction.y);

        isWalking = dir3 != Vector3.zero;
        isRunning = false;

        if (gameInput.GetIsHoldingShift()) {
            isRunning = true;
            isWalking = false;
            transform.position += dir3 * Time.deltaTime * 2*playerSpeed;
        }
        else {
            transform.position += dir3 * Time.deltaTime * playerSpeed;
        }
    }

    public bool IsWalking() {
        return isWalking;
    }

    public bool IsRunning() {
        return isRunning;
    }
}
