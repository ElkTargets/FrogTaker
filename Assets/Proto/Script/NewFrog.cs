using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Proto.Script
{
    public class NewFrog : MonoBehaviour
    {
        public static Sprite FrogSprite;
        public static string FrogName;
    
        public Image frogImage;
        public TextMeshProUGUI frogNameText;
        
        public Animation newFrogAnimation;
        
        public static bool corroutineStart;
        

        private void FixedUpdate()
        {
            frogImage.sprite = FrogSprite;
            frogNameText.text = FrogName;
            if (corroutineStart)
            {
                StartCoroutine(DisplayNewFrog());
                corroutineStart = false;
            }
        }

        public IEnumerator DisplayNewFrog()
        {
            yield return new WaitForSeconds(1f);
            newFrogAnimation.Play();
            
            yield return new WaitForSeconds(1.5f);
            GetComponent<RectTransform>().localScale = Vector3.zero;
        }


    }
}
