using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour
{
    [SerializeField] private Quest _selectedQuest;
    [SerializeField] private Step _selectedStep;
    [SerializeField] TMP_Text _nameText;

    public void SelectQuest(Quest quest)
    {
        _selectedQuest = quest;
        Bind();
    }

    [SerializeField] TMP_Text _descriptionText;
    [SerializeField] TMP_Text _currentObjectivesText;
    [SerializeField] Image _iconImage;

    [ContextMenu("Bind")]
    public void Bind()
    {
        _nameText.SetText(_selectedQuest.DisplayName);
        _descriptionText.SetText(_selectedQuest.Description);

        _selectedStep = _selectedQuest.Steps.FirstOrDefault();

        DisplayStepInstructionsAndObjectives();
    }

    private void DisplayStepInstructionsAndObjectives()
    {
        StringBuilder builder = new StringBuilder();
        if (_selectedStep != null)
        {
            builder.AppendLine(_selectedStep.Instructions);
            foreach (var objective in _selectedStep.Objectives)
            {
                builder.AppendLine(objective.ToString());
            }
        }

        _currentObjectivesText.SetText(builder.ToString());
    }
}
