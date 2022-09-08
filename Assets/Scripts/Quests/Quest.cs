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

    public List<Step> Steps;

    public string Description => _description;

    public string DisplayName => _displayName;
}

[Serializable]
public class Step
{
    [SerializeField] private string _instructions;
    public string Instructions => _instructions;
    public List<Objective> Objectives;
}

[Serializable]
public class Objective
{
    [SerializeField] private ObjectiveType _objectiveType;

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