using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    public event Action Progressed;

    [SerializeField] private string _displayName;
    [SerializeField] private string _description;

    [Tooltip("Notes for ideas or obtaining more information")]
    [SerializeField] private string _notes;

    private int _currentStepIndex;

    public List<Step> Steps;

    public string Description => _description;

    public string DisplayName => _displayName;

    public Step CurrentStep => Steps[_currentStepIndex];

    private void OnEnable()
    {
        _currentStepIndex = 0;
    }

    public void TryProgress()
    {
        var currentStep = GetCurrentStep();
        if (currentStep.HasAllObjectivesCompleted())
        {
            _currentStepIndex++;
            Progressed?.Invoke();
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
    [SerializeField] private GameFlag _gameFlag;

    public bool IsCompleted
    {
        get
        {
            switch (_objectiveType)
            {
                case ObjectiveType.Flag: return _gameFlag.Value;
                default: return false;
            }
        }
    }

    public enum ObjectiveType
    {
        Flag,
        Item,
        Kill,
    }

    public override string ToString()
    {
        switch (_objectiveType)
        {
            case ObjectiveType.Flag: return _gameFlag.name;
            default: return _objectiveType.ToString();
        }
    }
}