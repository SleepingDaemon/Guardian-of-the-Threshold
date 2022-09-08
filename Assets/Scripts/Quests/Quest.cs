using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;

    [Tooltip("Notes for ideas or obtaining more information")]
    [SerializeField] private string _notes;

    public List<Step> Steps;
}

[Serializable]
public class Step
{
    [SerializeField] private string _instructions;
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
}