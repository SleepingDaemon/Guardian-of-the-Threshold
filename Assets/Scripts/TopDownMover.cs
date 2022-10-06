using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMover : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Vector3 direction = Vector3.zero;
    private Rigidbody rb;
    private Animator _animator;
    private PlayerControls _playerControls;

    private void OnEnable()
    {
        _playerControls?.Enable();
    }

    private void OnDisable()
    {
        _playerControls?.Disable();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        _playerControls = new PlayerControls();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && direction == Vector3.zero)
        {
            _animator.SetBool("IsSitting", true);
        }
    }

    private void FixedUpdate()
    {
        float xMove = _playerControls.Player.Movement.ReadValue<Vector2>().x;
        float zMove = _playerControls.Player.Movement.ReadValue<Vector2>().y;
        direction = new Vector3(xMove, 0, zMove);
        rb.velocity = direction.normalized * speed;

        if (direction != Vector3.zero)
        {
            _animator.SetFloat("x", xMove);
            _animator.SetFloat("z", zMove);
            _animator.SetBool("IsRunning", true);
            _animator.SetBool("IsSitting", false);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }
}
