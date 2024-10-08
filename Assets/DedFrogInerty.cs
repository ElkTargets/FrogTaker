using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DedFrogInerty : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-1.15f, 4f), ForceMode2D.Impulse);
        StartCoroutine(Anihilation());
    }

    private IEnumerator Anihilation()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<Animation>().Play();
        yield return new WaitForSeconds(0.42f);
        DestroyImmediate(this.gameObject);
    }
}
