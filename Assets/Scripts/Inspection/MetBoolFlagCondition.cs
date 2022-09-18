using UnityEngine;

public class MetBoolFlagCondition : MonoBehaviour, IMet
{
    [SerializeField] BoolGameFlag _requiredFlag;

    public bool Met()
    {
        return _requiredFlag.Value;
    }
}
