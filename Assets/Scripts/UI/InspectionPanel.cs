using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InspectionPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _hintText;
    [SerializeField] private Image _progressBarFilledImage;
    [SerializeField] private GameObject _progressBar;

    private void OnEnable()
    {
        _hintText.enabled = false;
        Inspectable.InspectablesInRangeChanged += UpdateHintTextState;
    }

    private void OnDisable()
    {
        Inspectable.InspectablesInRangeChanged -= UpdateHintTextState;
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
