using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProto : MonoBehaviour
{
    public float moveSpeed = 5f;
    public SpriteRenderer spriteRenderer;
    public float moveValue;
    public bool PC;
    public Animator animator;
    
    void Update()
    {
        if (PC) { moveValue = Input.GetAxis("Horizontal");};
        if (moveValue != 0) {
            animator.SetBool("isWalking", true);
            if (moveValue > 0) { spriteRenderer.flipX = false; }
            if (moveValue < 0) { spriteRenderer.flipX = true; } 
            transform.Translate(moveValue * moveSpeed * Time.deltaTime, 0, 0);
        }
        else {
            animator.SetBool("isWalking", false);
        }
    }

    public void moveRight()
    {
        moveValue = 1;
    }

    public void noMove()
    {
        moveValue = 0;
    }

    public void moveLeft()
    {
        moveValue = -1;
    }
}
