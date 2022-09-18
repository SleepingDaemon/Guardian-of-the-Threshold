using UnityEngine;

public class MetCountedIntFlagCondition : MonoBehaviour, IMet
{
    [SerializeField] private IntGameFlag _requiredFlag;
    [SerializeField] private int _amountRequired = 4;

    public bool Met()
    {
        return _requiredFlag.Value >= _amountRequired;
    }
}