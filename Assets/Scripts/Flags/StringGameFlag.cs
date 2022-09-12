using UnityEngine;

[CreateAssetMenu(fileName = "StringFlag", menuName = "Game Flags/String")]
public class StringGameFlag : GameFlag<string>
{
    protected override void SetFromData(string value)
    {
        Set(value);
    }
}
