using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpMarchand : MonoBehaviour
{
    public Transform anchor;
    public GameObject leftBox;
    public GameObject rightBox;
    public GameObject marchand;
    public bool marchandHere;
    private List<TpMarchand> marchands = new List<TpMarchand>();

    private void Start()
    {
        foreach (TpMarchand tp in FindObjectsOfType<TpMarchand>())
        {
            if(tp != this) marchands.Add(tp);
        }
    }

    public void TeleportTheGuy()
    {
        marchand.transform.position = anchor.position;
        foreach (TpMarchand tp in marchands)
        {
            tp.marchandHere = false;
        }
        marchandHere = true;
    }
}
