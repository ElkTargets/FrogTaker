using System;
using UnityEngine;

namespace Proto.Script
{
    public class BuissonProto : MonoBehaviour
    {
        public bool playerDetected;

        public GameObject hillight;

        public bool somethingInside;
        public bool empty;

        private void Awake() {
            playerDetected = false;
            hillight.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player") && !empty) {
                playerDetected = true;
                hillight.SetActive(true);
            }
        }
        private void OnTriggerExit2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                playerDetected = false;
                hillight.SetActive(false);
            }
        }

        private void FixedUpdate() {
            if (playerDetected) {
                if (Input.GetAxis("Vertical") > 0.1f) {
                    if (!somethingInside) {
                        Debug.Log("Ce buisson est vide");
                        empty = true;
                        hillight.SetActive(false);
                    }
                    else {
                        Debug.Log("Il y a quelque chose dans ce buisson");
                        empty = true;
                        hillight.SetActive(false);
                    }
                }
            }
        }
    }
}
