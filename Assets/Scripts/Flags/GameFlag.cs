using System;
using UnityEngine;

public abstract class GameFlag<T> : GameFlagBase
{
    public T Value { get; protected set; }

    protected void OnDisable()
    {
        Value = default;
    }

    protected void OnEnable()
    {
        Value = default;
    }
}