using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoxTime : MonoBehaviour
{
    [SerializeField] private float _duration = 1f;
    [SerializeField] private Vector3 _magnitude = Vector3.down;
    [SerializeField] private AnimationCurve _curve = AnimationCurve.Linear(0f, 0f, 1, 1f);

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _elapsedTime;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void OnEnable()
    {
        _elapsedTime = 0f;
        _endPosition = _startPosition + _magnitude;
    }

    private void OnDisable()
    {
        transform.position = _startPosition;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        float pctElapsed = _elapsedTime / _duration;
        float pctOnCurve = _curve.Evaluate(pctElapsed);
        transform.position = Vector3.Lerp(_startPosition, _endPosition, pctOnCurve);
    }
}
