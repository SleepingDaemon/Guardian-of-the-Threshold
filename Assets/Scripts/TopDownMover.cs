using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMover : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Vector3 direction = Vector3.zero;
    private Rigidbody rb;
    private Animator _animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        direction = new Vector3(xMove, 0, zMove);
        rb.velocity = direction.normalized * speed;

        if (direction != Vector3.zero)
        {
            _animator.SetFloat("x", xMove);
            _animator.SetFloat("z", zMove);
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }
}
