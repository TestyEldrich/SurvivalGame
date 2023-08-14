using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]private float playerSpeed = 8f;
    private bool m_FacingRight = false;
    private void Update(){
        Vector2 direction = new Vector2 (0,0);

        if (Input.GetKey(KeyCode.W)) {
            direction.y -= 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            direction.x += 1;
            if(m_FacingRight == true) {
                m_FacingRight = false;
                transform.localRotation = Quaternion.Euler(180, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.S)) {
            direction.y += 1;
        }
        if (Input.GetKey(KeyCode.D)) {
            direction.x -= 1;
            if (m_FacingRight == false) {
                m_FacingRight = true;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        direction = direction.normalized;
        Vector3 dir3 = new(direction.x, 0, direction.y);

        if (Input.GetKey(KeyCode.LeftShift)) {
            transform.position += dir3 * Time.deltaTime * 2*playerSpeed;
        }
        else {
            transform.position += dir3 * Time.deltaTime * playerSpeed;
        }

    }
}
