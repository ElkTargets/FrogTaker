using System;
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
    private bool _isMoving;
    private bool _facingRight;
    public SpriteRenderer hatSpriteRenderer;
    public int money;

    private void Awake()
    {
        _facingRight = true;
        _isMoving = false;
    }

    void Update()
    {
        if (PC) { moveValue = Input.GetAxis("Horizontal");};
        if (moveValue != 0) {
            animator.SetBool("isWalking", true);
            transform.Translate(moveValue * moveSpeed * Time.deltaTime, 0, 0);
        }
        else {
            animator.SetBool("isWalking", false);
        }
    }

    public void moveRight()
    {
        if (!_isMoving && !_facingRight)
        {
            StartCoroutine(flipRight());
        }
        _isMoving = true;
        moveValue = 1;
    }

    public void noMove()
    {
        _isMoving = false;
        moveValue = 0;
    }

    public void moveLeft()
    {
        if (!_isMoving && _facingRight)
        {
            StartCoroutine(flipLeft());
        }
        _isMoving = true;
        moveValue = -1;
    }

    private IEnumerator flipRight() {
        if (!_facingRight) {
            Quaternion startRotation = spriteRenderer.transform.rotation;
            Quaternion endRotation = Quaternion.Euler(0, 0, 0);
            float elapsedTime = 0f;
            float duration = 0.25f;
            while (elapsedTime < duration) {
                spriteRenderer.transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            spriteRenderer.transform.rotation = endRotation;
        }
        _facingRight = true;
    }

    private IEnumerator flipLeft()
    {
        if (_facingRight) {
            Quaternion startRotation = spriteRenderer.transform.rotation;
            Quaternion endRotation = Quaternion.Euler(0, 180, 0);
            float elapsedTime = 0f;
            float duration = 0.25f;
            while (elapsedTime < duration) {
                spriteRenderer.transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            spriteRenderer.transform.rotation = endRotation;
        }
        _facingRight = false;
    }
}
