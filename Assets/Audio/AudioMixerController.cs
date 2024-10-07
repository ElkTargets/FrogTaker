using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerController : MonoBehaviour
{
    public AudioMixer audioMixer; // Référence à l'AudioMixer
    public Slider volumeSlider; // Référence au slider
    public string volumeParameter = "Volume"; // Nom du paramètre exposé dans l'AudioMixer

    void Start()
    {
        // Vérifiez que l'AudioMixer et le slider sont définis
        if (audioMixer == null)
        {
            Debug.LogError("AudioMixer is not assigned.");
            return;
        }

        if (volumeSlider == null)
        {
            Debug.LogError("Volume Slider is not assigned.");
            return;
        }

        // Initialiser le slider avec la valeur actuelle du paramètre de volume
        float currentVolume;
        if (audioMixer.GetFloat(volumeParameter, out currentVolume))
        {
            volumeSlider.value = Mathf.Pow(10, currentVolume / 20);
        }

        // Ajouter un listener pour mettre à jour le volume lorsque le slider change
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float sliderValue)
    {
        // Convertir la valeur du slider en décibels
        float volume = Mathf.Log10(sliderValue) * 20;
        audioMixer.SetFloat(volumeParameter, volume);
        //Debug.Log($"Volume set to {volume} dB");
    }
}