using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProto : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    void Update()
    {
        float moveAxis = Input.GetAxis("Horizontal");
        if (moveAxis != 0)
        {
            transform.Translate(moveAxis * moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
