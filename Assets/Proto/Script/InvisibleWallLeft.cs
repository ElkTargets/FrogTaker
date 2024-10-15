using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWallLeft : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(other.transform.position.x + 0.1f, 0, 0);
        }
    }
}
