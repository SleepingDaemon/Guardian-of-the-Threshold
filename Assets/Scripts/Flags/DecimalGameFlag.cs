using UnityEngine;

[CreateAssetMenu(fileName = "DecimalFlag", menuName = "Game Flags/Decimal")]
public class DecimalGameFlag : GameFlag<decimal>
{
    protected override void SetFromData(string value)
    {
        if(decimal.TryParse(value, out var decimalValue))
        {
            Set(decimalValue);
        }
    }
}
