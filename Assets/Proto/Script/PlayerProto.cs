using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProto : MonoBehaviour
{
    public float moveSpeed = 5f;
    public SpriteRenderer spriteRenderer;
    
    void Update()
    {
        float moveAxis = Input.GetAxis("Horizontal");
        if (moveAxis != 0) {
            if (moveAxis > 0) { spriteRenderer.flipX = false; }
            if (moveAxis < 0) { spriteRenderer.flipX = true; } 
            transform.Translate(moveAxis * moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
