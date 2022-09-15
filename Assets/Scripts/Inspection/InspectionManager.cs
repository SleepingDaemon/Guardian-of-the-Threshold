using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InspectionManager : MonoBehaviour
{
    private static Inspectable _currentInspectable;

    public static float InspectionProgress => _currentInspectable?.InspectionProgress ?? 0f;
    public static bool Inspecting => _currentInspectable != null && _currentInspectable.isActiveAndEnabled;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            _currentInspectable = Inspectable.InspectablesInRange.FirstOrDefault();
        if (Input.GetKey(KeyCode.E) && _currentInspectable != null)
            _currentInspectable.Inspect();
        else
            _currentInspectable = null;
    }
}
