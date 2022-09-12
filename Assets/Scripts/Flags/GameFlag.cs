using System;
using UnityEngine;

public abstract class GameFlag<T> : GameFlagBase
{
    public T Value { get; private set; }
    public void Set(T value)
    {
        Value = value;
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