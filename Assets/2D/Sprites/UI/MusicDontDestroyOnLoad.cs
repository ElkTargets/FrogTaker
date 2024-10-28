using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDontDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
