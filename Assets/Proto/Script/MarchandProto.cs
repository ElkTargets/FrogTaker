using UnityEngine;

namespace Proto.Script
{
    public class MarchandProto : MonoBehaviour
    {
    
        public bool playerDetected;

        public GameObject hillight;
    
        private void Awake() {
            playerDetected = false;
            hillight.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
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
    }
}
