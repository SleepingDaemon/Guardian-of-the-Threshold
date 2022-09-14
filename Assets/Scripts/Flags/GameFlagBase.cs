using System;
using UnityEngine;

public abstract class GameFlagBase : ScriptableObject
{
    public GameFlagData GameFlagData { get; private set; }
    public event Action Changed;
    protected void SendChanged() => Changed?.Invoke();

    public void Bind(GameFlagData gameFlagData)
    {
        GameFlagData = gameFlagData;
        SetFromData(GameFlagData.Value);
    }

    protected abstract void SetFromData(string value);
}

public abstract class GameFlag<T> : GameFlagBase
{
    public T Value { get; private set; }
    public void Set(T value)
    {
        Value = value;
        GameFlagData.Value = Value.ToString();
        SendChanged();
    }

    protected void OnDisable()
    {
        Value = default;
    }

    protected void OnEnable()
    {
        Value = default;
    }
}

[Serializable]
public class GameFlagData
{
    public string Name;
    public string Value;
}