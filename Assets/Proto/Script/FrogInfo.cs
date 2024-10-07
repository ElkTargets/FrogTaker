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

        public void DisplayPanel(FrogData frogData)
        {
            nameTMP.text = frogData.frogName;
            descriptionTMP.text = frogData.frogDescription;
            image.sprite = frogData.frogSprite;
        }
    }
}
