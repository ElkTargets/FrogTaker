using System;
using Frogs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Proto.Script
{
    public class FrogInfo : MonoBehaviour
    {
        public TextMeshProUGUI nameTMP;
        public TextMeshProUGUI descriptionTMP;
        public Image image;
        public AudioSource audioSource;
        public Animator animator;

        public void DisplayPanel(FrogData frogData)
        {
            animator.SetTrigger("Spawn");
            nameTMP.text = frogData.frogName;
            descriptionTMP.text = frogData.frogDescription;
            image.sprite = frogData.frogSprite;
            audioSource.clip = frogData.frogSound;
        }

        public void HidePanel()
        {
            animator.SetTrigger("Dispawn");
        }
        
    }
}
