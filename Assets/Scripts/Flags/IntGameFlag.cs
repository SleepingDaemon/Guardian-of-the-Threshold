using System;
using UnityEngine;

[CreateAssetMenu(fileName = "IntFlag", menuName = "Game Flags/Int")]
public class IntGameFlag : GameFlag<int>
{
    public void Modify(int value)
    {
        Value += value;
        SendChanged();
    }

    public void Set(int value)
    {
        Value = value;
        SendChanged();
    }
}
