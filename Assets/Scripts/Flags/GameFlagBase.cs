using System;
using UnityEngine;

public abstract class GameFlagBase : ScriptableObject
{
    public event Action Changed;
    protected void SendChanged() => Changed?.Invoke();
}