using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    public event Action Changed;

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
        foreach (var step in Steps)
        {
            foreach (var objective in step.Objectives)
            {
                if(objective.GameFlag != null)
                {
                    objective.GameFlag.Changed += HandleFlagChanged;
                }
            }
        }
    }

    private void HandleFlagChanged()
    {
        TryProgress();
        Changed?.Invoke();
    }

    public void TryProgress()
    {
        var currentStep = GetCurrentStep();
        if (currentStep.HasAllObjectivesCompleted())
        {
            _currentStepIndex++;
            Changed?.Invoke();
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
