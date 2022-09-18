using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _distance = 2f;
    private Transform _target;
    private Rigidbody _rb;
    private Animator _anim;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        _target = FindObjectOfType<TopDownMover>().transform;
    }

    private void FixedUpdate()
    {
        if(_target == null)
            _target = FindObjectOfType<TopDownMover>().transform;

        if(_target != null)
        {
            Vector3 direction = _target.position - transform.position;
            float x = direction.x;
            float z = direction.z;

            if (direction.sqrMagnitude >= _distance)
            {
                _rb.velocity = direction.normalized * _speed;
                _anim.SetBool("IsRunning", true);
            }
            else
            {
                _anim.SetBool("IsRunning", false);
            }

            if (_target.position != Vector3.zero)
            {
                _anim.SetFloat("x", x);
                _anim.SetFloat("z", z);
            }
        }
    }
}
