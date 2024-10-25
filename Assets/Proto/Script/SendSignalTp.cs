using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendSignalTp : MonoBehaviour
{
    public TpMarchand tpMarchand;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && tpMarchand.marchandHere == false)
        {
            tpMarchand.TeleportTheGuy();
        }
    }
}
