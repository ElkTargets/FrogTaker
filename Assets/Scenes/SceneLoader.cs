using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNewScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
