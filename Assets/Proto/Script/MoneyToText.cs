using System;
using TMPro;
using UnityEngine;

namespace Proto.Script
{
    public class MoneyToText : MonoBehaviour
    {
        public TextMeshProUGUI moneyText;
        private PlayerProto _player;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerProto>();
        }

        private void FixedUpdate()
        {
            moneyText.text = _player.money.ToString();
        }
    }
}
