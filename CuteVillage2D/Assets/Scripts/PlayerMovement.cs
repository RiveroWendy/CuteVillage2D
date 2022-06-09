using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _movement;
    private Rigidbody2D _rigibody;
    [SerializeField]private int _speed = 5;
    private Animator _animator;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
  
    private void OnMovement(InputValue value)
    {
        _movement = value.Get<Vector2>();

        if (_movement.x != 0 || _movement.y !=0)
        {
            _animator.SetFloat("X", _movement.x);
            _animator.SetFloat("Y", _movement.y);

            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {

        _rigibody.MovePosition(_rigibody.position + _movement * _speed * Time.fixedDeltaTime);
    }
}

