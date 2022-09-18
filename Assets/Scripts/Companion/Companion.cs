using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceFromTarget = 6f;
    private Rigidbody _rb = null;
    private Animator _anim = null;
    private Transform _target = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponentInChildren<Animator>();
        _target = FindObjectOfType<TopDownMover>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = _target.position - transform.position;
        float x = direction.x;
        float z = direction.z;

        if (direction != Vector3.zero)
        {
            _anim.SetFloat("x", x);
            _anim.SetFloat("z", z);
        }

        if (direction.magnitude >= _distanceFromTarget)
        {
            _rb.velocity = direction.normalized * _speed;

            _anim.SetFloat("x", x);
            _anim.SetFloat("z", z);
            _anim.SetBool("IsRunning", true);
        }
        else
        {
            _anim.SetBool("IsRunning", false);
        }
    }
}
