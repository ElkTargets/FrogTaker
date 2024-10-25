using System;
using System.Reflection;
using Frogs;
using UnityEngine;
using UnityEngine.Serialization;

namespace Proto.Script
{
    public class BuissonProto : MonoBehaviour
    {
        public bool playerDetected;

        public GameObject hillight;

        public bool somethingInside;
        public bool empty;
        public FrogData frog;
        public AudioSource audioSource;

        public GameObject dedFrog;
        
        

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
                    Fouiller();
                }
            }
        }

        public void Fouiller() {
            if (!somethingInside) {
                Debug.Log("Ce buisson est vide");
                empty = true;
                hillight.SetActive(false);
            }
            else {
                Debug.Log("Il y a quelque chose dans ce buisson");
                empty = true;
                
                hillight.SetActive(false); 
                
                NewFrog.FrogName = frog.frogName;
                NewFrog.FrogSprite = frog.frogSprite;
                NewFrog.corroutineStart = true;
                audioSource.clip = frog.frogSound;
                audioSource.Play();
                
                GameObject newDedFrog = Instantiate(dedFrog, this.transform.position, Quaternion.identity);
                newDedFrog.GetComponent<SpriteRenderer>().sprite = frog.frogSprite;
                
                Type type = typeof(FrogDexUnlocks);
                FieldInfo field = type.GetField(frog.name, BindingFlags.Public | BindingFlags.Static);

                if (field != null && field.FieldType == typeof(bool))
                {
                    field.SetValue(null, true);
                }

                FindObjectOfType<PlayerProto>().money += 1;

            }
        }
    }
}
