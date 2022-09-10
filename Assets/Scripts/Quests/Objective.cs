using System;
using UnityEngine;

[Serializable]
public class Objective
{
    [SerializeField] private ObjectiveType _objectiveType;
    [SerializeField] private GameFlagBase _gameFlag;
    [SerializeField] private int _required;
    [SerializeField] private string _stringValue;

    public GameFlagBase GameFlag => _gameFlag;

    public bool IsCompleted
    {
        get
        {
            switch (_objectiveType)
            {
                case ObjectiveType.GameFlag:
                    {
                        if (_gameFlag is BoolGameFlag boolGameFlag)
                            return boolGameFlag.Value;
                        if (_gameFlag is IntGameFlag intGameFlag)
                            return intGameFlag.Value >= _required;
                        return false;
                    }
                default: return false;
            }
        }
    }

    public enum ObjectiveType
    {
        GameFlag,
        Item,
        Kill,
    }

    public override string ToString()
    {
        switch (_objectiveType)
        {
            case ObjectiveType.GameFlag:
                {
                    if(_gameFlag is BoolGameFlag)
                        return _gameFlag.name;
                    if (_gameFlag is IntGameFlag intGameFlag)
                        return $"{intGameFlag.name} ({intGameFlag.Value}/{_required})";
                    return "Unknown Objective Type";
                }
            default: return _objectiveType.ToString();
        }
    }
}