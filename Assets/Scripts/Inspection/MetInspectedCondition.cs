using System;
using UnityEngine;

public class MetInspectedCondition : MonoBehaviour, IMet
{
    [SerializeField] Inspectable _requiredInspectable;

    public bool Met()
    {
        return _requiredInspectable.WasFullyInspected;
    }
}
