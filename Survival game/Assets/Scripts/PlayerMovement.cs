using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float playerSpeed = 8f;
    private bool isFacingRight = false;
    private bool isWalking;
    private bool isRunning;
    private void Update(){
        Vector2 direction = new Vector2 (0,0);

        if (Input.GetKey(KeyCode.W)) {
            direction.y -= 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            direction.x += 1;
            if(isFacingRight) {
                isFacingRight = false;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        if (Input.GetKey(KeyCode.S)) {
            direction.y += 1;
        }
        if (Input.GetKey(KeyCode.D)) {
            direction.x -= 1;
            if (!isFacingRight) {
                isFacingRight = true;
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        direction = direction.normalized;

        Vector3 dir3 = new(direction.x, 0, direction.y);

        isWalking = dir3 != Vector3.zero;
        isRunning = false;

        if (Input.GetKey(KeyCode.LeftShift)) {
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
