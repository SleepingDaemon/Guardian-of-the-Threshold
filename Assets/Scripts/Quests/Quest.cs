using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    [SerializeField] private string _displayName;
    [SerializeField] private string _description;

    [Tooltip("Notes for ideas or obtaining more information")]
    [SerializeField] private string _notes;

    private int _currentStepIndex;

    public List<Step> Steps;

    public string Description => _description;

    public string DisplayName => _displayName;

    public void TryProgress()
    {
        var currentStep = GetCurrentStep();
        if (currentStep.HasAllObjectivesCompleted())
        {
            _currentStepIndex++;
            // do whatever we do when a quest progresses like update UI
        }
    }

    private Step GetCurrentStep()
    {
        return Steps[_currentStepIndex];
    }
}

[Serializable]
public class Step
{
    [SerializeField] private string _instructions;
    public string Instructions => _instructions;
    public List<Objective> Objectives;

    public bool HasAllObjectivesCompleted()
    {
        return Objectives.TrueForAll(t => t.IsCompleted);
    }
}

[Serializable]
public class Objective
{
    [SerializeField] private ObjectiveType _objectiveType;

    public bool IsCompleted { get; }

    public enum ObjectiveType
    {
        Flag,
        Item,
        Kill,
    }

    public override string ToString()
    {
        return _objectiveType.ToString();
    }
}