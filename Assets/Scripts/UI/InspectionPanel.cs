using TMPro;
using UnityEngine;

public class InspectionPanel : MonoBehaviour
{
     [SerializeField] private TMP_Text _hintText;

    private void OnEnable()
    {
        _hintText.enabled = false;
        Inspectable.InspectablesInRangeChanged += UpdateHintTextState;
    }

    private void OnDisable()
    {
        Inspectable.InspectablesInRangeChanged -= UpdateHintTextState;
    }

    private void UpdateHintTextState(bool enableHintText)
    {
        _hintText.enabled = enableHintText;
    }
}
