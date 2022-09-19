using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InspectionPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _hintText;
    [SerializeField] private TMP_Text _inspectionCompleteText;
    [SerializeField] private Image _progressBarFilledImage;
    [SerializeField] private GameObject _progressBar;
    [SerializeField] private float _fadeDuration = 1f;

    private void OnEnable()
    {
        _hintText.enabled = false;
        _inspectionCompleteText.enabled = false;
        Inspectable.InspectablesInRangeChanged += UpdateHintTextState;
        Inspectable.AnyInspectionComplete += HandleAnyInspectionCompleted;
    }

    private void HandleAnyInspectionCompleted(Inspectable inspectable, string inspectionCompleteMessage)
    {
        _inspectionCompleteText.SetText(inspectionCompleteMessage);
        _inspectionCompleteText.enabled = true;

        StartCoroutine(FadeInspectionCompleteText());
    }

    private IEnumerator FadeInspectionCompleteText()
    {
        _inspectionCompleteText.alpha = 1f;

        while(_inspectionCompleteText.alpha > 0)
        {
            yield return new WaitForSeconds(_fadeDuration);
            _inspectionCompleteText.alpha -= Time.deltaTime;
        }

        _inspectionCompleteText.enabled = false;
    }

    private void OnDisable()
    {
        Inspectable.InspectablesInRangeChanged -= UpdateHintTextState;
        Inspectable.AnyInspectionComplete -= HandleAnyInspectionCompleted;
    }

    private void Update()
    {
        if(InspectionManager.Inspecting)
        {
            _progressBarFilledImage.fillAmount = InspectionManager.InspectionProgress;
            _progressBar.SetActive(true);
        }
        else if (_progressBar.activeSelf)
        {
            _progressBar.SetActive(false);
        }
    }

    private void UpdateHintTextState(bool enableHintText)
    {
        _hintText.enabled = enableHintText;
    }
}
