using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Proto.Script
{
    public class MarchandProto : MonoBehaviour
    {
    
        private bool _playerDetected;
        private PlayerProto _player;
        private bool _facingRight;
        public GameObject visualRotatif;
        
        // Chapeau Invisible
        private bool _hat1;
        private bool _hat1Buy;
        public int hat1Price;
        public TextMeshProUGUI hat1PriceText;
        
        // Chapeau Haut de Forme
        private bool _hat2;
        private bool _hat2Buy;
        public int hat2Price;
        public TextMeshProUGUI hat2PriceText;
        
        // Chapeau Melon
        private bool _hat3;
        private bool _hat3Buy;
        public int hat3Price;
        public TextMeshProUGUI hat3PriceText;
        
        private bool _hat4;
        private bool _hat4Buy;
        public int hat4Price;
        public TextMeshProUGUI hat4PriceText;
        
        private bool _hat5;
        private bool _hat5Buy;
        public int hat5Price;
        public TextMeshProUGUI hat5PriceText;
        
        private bool _hat6;
        private bool _hat6Buy;
        public int hat6Price;
        public TextMeshProUGUI hat6PriceText;

        public Image hatSlotUI;
        public TextMeshProUGUI buyButtonText;
        public Sprite hat1Sprite;
        public Sprite hat2Sprite;
        public Sprite hat3Sprite;
        public Sprite hat4Sprite;
        public Sprite hat5Sprite;
        public Sprite hat6Sprite;

        public GameObject hillight;
        public GameObject hillightSprite;
    
        private void Awake() {
            _playerDetected = false;
            hillight.SetActive(false);
            hillightSprite.SetActive(false);
            _hat1 = true;
            _hat1Buy = true;
            _player = FindObjectOfType<PlayerProto>();
            _facingRight = true;
            DisplayPrices();
        }

        private void DisplayPrices ()
        {
            hat1PriceText.text = hat1Price.ToString();
            hat2PriceText.text = hat2Price.ToString();
            hat3PriceText.text = hat3Price.ToString();
            hat4PriceText.text = hat4Price.ToString();
            hat5PriceText.text = hat5Price.ToString();
            hat6PriceText.text = hat6Price.ToString();
        }

        private void OnEnable()
        {
            if (_hat1Buy && _hat1) { buyButtonText.text = "Equip"; }
            else if (_hat2Buy && _hat2) { buyButtonText.text = "Equip"; }
            else if (_hat3Buy && _hat3) { buyButtonText.text = "Equip"; }
            else if (_hat4Buy && _hat4) { buyButtonText.text = "Equip"; }
            else if (_hat5Buy && _hat5) { buyButtonText.text = "Equip"; }
            else if (_hat6Buy && _hat6) { buyButtonText.text = "Equip"; }
            else { buyButtonText.text = "Buy"; }
        }
        
        public void ChangeBuyButtonText()
        {
            if (_hat1Buy && _hat1) { buyButtonText.text = "Equip"; }
            else if (_hat2Buy && _hat2) { buyButtonText.text = "Equip"; }
            else if (_hat3Buy && _hat3) { buyButtonText.text = "Equip"; }
            else if (_hat4Buy && _hat4) { buyButtonText.text = "Equip"; }
            else if (_hat5Buy && _hat5) { buyButtonText.text = "Equip"; }
            else if (_hat6Buy && _hat6) { buyButtonText.text = "Equip"; }
            else { buyButtonText.text = "Buy"; }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                _playerDetected = true;
                hillight.SetActive(true);
                hillightSprite.SetActive(true);
                
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (other.transform.position.x > transform.position.x && !_facingRight)
                {
                    StartCoroutine(FlipRight());
                }
                if (other.transform.position.x < transform.position.x && _facingRight)
                {
                    StartCoroutine(FlipLeft());
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                _playerDetected = false;
                hillight.SetActive(false);
                hillightSprite.SetActive(false);
            }
        }
        

        private void ChangeHatOnShop()
        {
            if (_hat1)
            {
                hatSlotUI.sprite = hat1Sprite;
            }
            else if (_hat2)
            {
                hatSlotUI.sprite = hat2Sprite;
            }
            else if (_hat3)
            {
                hatSlotUI.sprite = hat3Sprite;
            }
            else if (_hat4)
            {
                hatSlotUI.sprite = hat4Sprite;
            }
            else if (_hat5)
            {
                hatSlotUI.sprite = hat5Sprite;
            }
            else if (_hat6)
            {
                hatSlotUI.sprite = hat6Sprite;
            }
        }

        public void BuyOrEquip() {
            if (_hat1) {
                if (_hat1Buy) { _player.hatSpriteRenderer.sprite = hat1Sprite; }
                else {
                    if (_player.money >= hat1Price) {
                        _hat1Buy = true;
                        _player.hatSpriteRenderer.sprite = hat1Sprite;
                        _player.money -= hat1Price;
                        ChangeBuyButtonText();
                    }
                }
            }
            if (_hat2) {
                if (_hat2Buy) { _player.hatSpriteRenderer.sprite = hat2Sprite; }
                else {
                    if (_player.money >= hat2Price) {
                        _hat2Buy = true;
                        _player.hatSpriteRenderer.sprite = hat2Sprite;
                        _player.money -= hat2Price;
                        ChangeBuyButtonText();
                    }
                }
            }
            if (_hat3) {
                if (_hat3Buy) { _player.hatSpriteRenderer.sprite = hat3Sprite; }
                else {
                    if (_player.money >= hat3Price) {
                        _hat3Buy = true;
                        _player.hatSpriteRenderer.sprite = hat3Sprite;
                        _player.money -= hat3Price;
                        ChangeBuyButtonText();
                    }
                }
            }
            if (_hat4) {
                if (_hat4Buy){ _player.hatSpriteRenderer.sprite = hat4Sprite; }
                else {
                    if (_player.money >= hat4Price) {
                        _hat4Buy = true;
                        _player.hatSpriteRenderer.sprite = hat4Sprite;
                        _player.money -= hat4Price;
                        ChangeBuyButtonText();
                    }
                }
            }
            if (_hat5) {
                if (_hat5Buy) { _player.hatSpriteRenderer.sprite = hat5Sprite; }
                else {
                    if (_player.money >= hat5Price) {
                        _hat5Buy = true;
                        _player.hatSpriteRenderer.sprite = hat5Sprite;
                        _player.money -= hat5Price;
                        ChangeBuyButtonText();
                    }
                }
            }
            if (_hat6) {
                if (_hat6Buy) { _player.hatSpriteRenderer.sprite = hat6Sprite; }
                else {
                    if (_player.money >= hat6Price) {
                        _hat6Buy = true;
                        _player.hatSpriteRenderer.sprite = hat6Sprite;
                        _player.money -= hat6Price;
                        ChangeBuyButtonText();
                    }
                }
            }
        }
        
        private IEnumerator FlipRight() {
            if (!_facingRight) {
                Quaternion startRotation = visualRotatif.transform.rotation;
                Quaternion endRotation = Quaternion.Euler(0, 0, 0);
                float elapsedTime = 0f;
                float duration = 0.25f;
                while (elapsedTime < duration) {
                    visualRotatif.transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                visualRotatif.transform.rotation = endRotation;
            }
            _facingRight = true;
        }

        private IEnumerator FlipLeft()
        {
            if (_facingRight) {
                Quaternion startRotation = visualRotatif.transform.rotation;
                Quaternion endRotation = Quaternion.Euler(0, 180, 0);
                float elapsedTime = 0f;
                float duration = 0.25f;
                while (elapsedTime < duration) {
                    visualRotatif.transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                visualRotatif.transform.rotation = endRotation;
            }
            _facingRight = false;
        }
        
        public void Hat1() {
            if (!_hat1)
            {
                _hat1 = true;
                buyButtonText.text = !_hat1Buy ? "Equip" : "Buy";
            }
            _hat2 = false;
            _hat3 = false;
            _hat4 = false;
            _hat5 = false;
            _hat6 = false;
            ChangeHatOnShop();
        }
        public void Hat2() {
            if (!_hat2) {
                _hat2 = true;
                buyButtonText.text = !_hat2Buy ? "Equip" : "Buy";
            }
            _hat1 = false;
            _hat3 = false;
            _hat4 = false;
            _hat5 = false;
            _hat6 = false;
            ChangeHatOnShop();
        }
        public void Hat3() {
            if (!_hat3) {
                _hat3 = true;
                buyButtonText.text = !_hat3Buy ? "Equip" : "Buy";
            }
            _hat2 = false;
            _hat1 = false;
            _hat4 = false;
            _hat5 = false;
            _hat6 = false;
            ChangeHatOnShop();
        }
        public void Hat4() {
            if (!_hat4) {
                _hat4 = true;
                buyButtonText.text = !_hat4Buy ? "Equip" : "Buy";
            }
            _hat2 = false;
            _hat3 = false;
            _hat1 = false;
            _hat5 = false;
            _hat6 = false;
            ChangeHatOnShop();
        }
        public void Hat5() {
            if (!_hat5) {
                _hat5 = true;
                buyButtonText.text = !_hat5Buy ? "Equip" : "Buy";
            }
            _hat2 = false;
            _hat3 = false;
            _hat4 = false;
            _hat1 = false;
            _hat6 = false;
            ChangeHatOnShop();
        }
        public void Hat6() {
            if (!_hat6) {
                _hat6 = true;
                buyButtonText.text = !_hat6Buy ? "Equip" : "Buy";
            }
            _hat2 = false;
            _hat3 = false;
            _hat4 = false;
            _hat5 = false;
            _hat1 = false;
            ChangeHatOnShop();
        }

        public void FlipToTheLeft()
        {
            StartCoroutine(FlipLeft());
        }
    }
}
