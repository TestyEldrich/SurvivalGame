using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    private const string IS_RUNNING = "IsRunning";
    private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        animator.SetBool(IS_WALKING, playerMovement.IsWalking());
        animator.SetBool(IS_RUNNING, playerMovement.IsRunning());
    }
}
