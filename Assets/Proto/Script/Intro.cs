using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Introduction;
using Proto.Script;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Intro : MonoBehaviour
{
    public MarchandProto _marchandProto;
    public List<GameObject> canvasObjects = new List<GameObject>();
    public CinemachineCameraOffset vcam;
    public IntroTextData firstData;
    public IntroTextData currentData;
    public TextMeshProUGUI nameTMP;
    public Image portraitImage;
    public TextMeshProUGUI descriptionTMP;
    public GameObject IntroCanvas;
    
    private readonly Vector3 _targetOffset = new Vector3(2.15f, -0.25f, 0);
    private Vector3 _startOffset;
    private readonly float _duration = 1.25f;
    private float _elapsedTime = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartIntro();
            other.GetComponent<PlayerProto>().noMove();
            _marchandProto.FlipToTheLeft();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IntroCanvas.SetActive(false);
            Destroy(this.gameObject);
        } 
    }

    private void StartIntro()
    {
        foreach (GameObject canvasObject in canvasObjects)
        {
            canvasObject.SetActive(false);
            _startOffset = vcam.m_Offset;
            StartCoroutine(MoveOffset(_targetOffset));
        }
        IntroCanvas.SetActive(true);
        GetComponent<Animator>().SetTrigger("Spawn");
        ShowIntro();
    }
    
    IEnumerator MoveOffset(Vector3 target) {
        _elapsedTime = 0f;
        Vector3 initialOffset = vcam.m_Offset;
        while (_elapsedTime < _duration) {
            float t = _elapsedTime / _duration;
            vcam.m_Offset = Vector3.Lerp(initialOffset, target, t);
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        vcam.m_Offset = target;
    }

    [ContextMenu("Show Intro")]
    public void ShowIntro()
    {
        DisplayIntroData(firstData);
    }
    public float typingSpeed = 0.05f; // Vitesse de frappe
    public float shakeAmount = 0.9f; // Amplitude du tremblement
    public float shakeDuration = 0.1f; // Durée du tremblement
    private Coroutine _typingCoroutine;
    private void DisplayIntroData(IntroTextData data)
    {
        currentData = data;
        nameTMP.text = data.characterName;
        portraitImage.sprite = data.sprite;
        
        if (_typingCoroutine != null)
        {
            StopCoroutine(_typingCoroutine);
        }

        _typingCoroutine = StartCoroutine(TypeText(data.text));
    }
    private IEnumerator TypeText(string text)
    {
        descriptionTMP.text = "";
        foreach (char letter in text)
        {
            descriptionTMP.text += letter;
            StartCoroutine(ShakeText());
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    private IEnumerator ShakeText()
    {
        Vector3 originalPosition = descriptionTMP.transform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float x = Random.Range(-shakeAmount, shakeAmount);
            float y = Random.Range(-shakeAmount, shakeAmount);
            descriptionTMP.transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        descriptionTMP.transform.localPosition = originalPosition;
    }

    public void NextData()
    {
        if (currentData.nextData == null)
        {
            GetComponent<Animator>().SetTrigger("Dispawn");
            foreach (GameObject canvasObject in canvasObjects)
            {
                canvasObject.SetActive(true);
                StartCoroutine(MoveOffset(_startOffset));
            }
        }
        else
        {
            DisplayIntroData(currentData.nextData);
        }
        
    }
}
