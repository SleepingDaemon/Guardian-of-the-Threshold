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

[Serializable]
public class GameFlagData
{
    public string Name;
    public string Value;
}