using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inspectable : MonoBehaviour
{
    private static HashSet<Inspectable> _inspectablesInRange = new HashSet<Inspectable>();
    [SerializeField] private float _timeToInspect = 3f;
    [SerializeField] private UnityEvent OnInspectionCompleted;
    private InspectableData _data;

    public static event Action<bool> InspectablesInRangeChanged;
    public static IReadOnlyCollection<Inspectable> InspectablesInRange => _inspectablesInRange;
    public float InspectionProgress => _data.TimeInspected / _timeToInspect;
    public bool WasFullyInspected => InspectionProgress >= 1f;

    public void Bind(InspectableData inspectableData)
    {
        _data = inspectableData;
        if (_data.TimeInspected >= _timeToInspect)
        {
            CompleteInspection();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && WasFullyInspected == false)
        {
            _inspectablesInRange.Add(this);
            InspectablesInRangeChanged?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(_inspectablesInRange.Remove(this))
                InspectablesInRangeChanged?.Invoke(_inspectablesInRange.Any());
        }
    }

    public void Inspect()
    {
        _data.TimeInspected += Time.deltaTime;
        if(_data.TimeInspected >= _timeToInspect)
        {
            CompleteInspection();
        }
    }

    private void CompleteInspection()
    {
        _inspectablesInRange.Remove(this);
        InspectablesInRangeChanged?.Invoke(_inspectablesInRange.Any());
        OnInspectionCompleted?.Invoke();
    }
}
