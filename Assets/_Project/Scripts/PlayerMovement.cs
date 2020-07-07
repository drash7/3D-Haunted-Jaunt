using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float turnSpeed = 5f;
    private Animator _animator;
    private Rigidbody _rigidbody;
    private Vector3 _movement;
    private Quaternion _rotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        
        _movement.Set(horiz, 0, vert);
        _movement.Normalize();

        // calculate the angle John's facing
        Vector3 desiredForwardDirection = Vector3.RotateTowards(transform.forward, _movement, turnSpeed * Time.deltaTime, 0);
        _rotation = Quaternion.LookRotation(desiredForwardDirection);

        //transform.position += new vector3(horiz * speed * time.deltatime, 0, vert * speed * time.deltatime);

        bool hasHorizInput = !Mathf.Approximately(horiz, 0f);
        bool hasVertInput = !Mathf.Approximately(vert, 0f);
        bool isWalking = hasHorizInput || hasVertInput;
        _animator.SetBool("IsWalking", isWalking);
    }

    private void OnAnimatorMove()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement * _animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(_rotation);
    }

}
