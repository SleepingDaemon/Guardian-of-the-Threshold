using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : ToggleablePanel
{
    [SerializeField] private Quest _selectedQuest;
    [SerializeField] TMP_Text _nameText;
    [SerializeField] TMP_Text _descriptionText;
    [SerializeField] TMP_Text _currentObjectivesText;
    [SerializeField] Image _iconImage;

    private Step _selectedStep => _selectedQuest.CurrentStep;

    [ContextMenu("Bind")]
    public void Bind()
    {
        _nameText.SetText(_selectedQuest.DisplayName);
        _descriptionText.SetText(_selectedQuest.Description);

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

    public void SelectQuest(Quest quest)
    {
        if (_selectedQuest)
            _selectedQuest.Progressed -= DisplayStepInstructionsAndObjectives;

        _selectedQuest = quest;
        Bind();

        _selectedQuest.Progressed += DisplayStepInstructionsAndObjectives;
    }
}
