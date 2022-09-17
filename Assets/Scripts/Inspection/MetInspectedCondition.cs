using System;
using UnityEngine;

public class MetInspectedCondition : MonoBehaviour
{
    [SerializeField] Inspectable _requiredInspectable;

    public bool Met()
    {
        return _requiredInspectable.WasFullyInspected;
    }
}