﻿using UnityEngine;

[CreateAssetMenu(fileName = "IntFlag", menuName = "Game Flags/Int")]
public class IntGameFlag : GameFlag<int>
{
    public void Modify(int value)
    {
        Set(Value + value);
    }

    protected override void SetFromData(string value)
    {
        if (int.TryParse(value, out var intValue))
        {
            Set(intValue);
        }
    }
}
