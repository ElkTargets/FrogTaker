using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogDexAnims : MonoBehaviour
{
    public Animator animator;
    public GameObject arrowPanel;
    public GameObject fButtonPanel;
    public Button backButton;

    public void Disable()
    {
        arrowPanel.SetActive(true);
        fButtonPanel.SetActive(true);
    }

    public void BackButton()
    {
        animator.SetTrigger("Dispawn");
    }

    public void FrogDexButton()
    {
        animator.SetTrigger("Spawn");
    }

    public void EnableBackButton()
    {
        backButton.interactable = true;
    }

    public void DisableBackButton()
    {
        backButton.interactable = false;
    }
}
