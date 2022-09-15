using TMPro;
using UnityEngine;

public class InspectionPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _hintText;
    [SerializeField] private TMP_Text _progressText;

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
            _progressText.SetText(InspectionManager.InspectionProgress.ToString());
    }

    private void UpdateHintTextState(bool enableHintText)
    {
        _hintText.enabled = enableHintText;
    }
}
