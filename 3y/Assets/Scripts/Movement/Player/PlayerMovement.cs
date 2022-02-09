using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovementController
{
    
    [SerializeField] private int speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private BoxGroundCheck groundCheck;
    private bool _canJump;

    private Vector2 _direction;

    private bool _jumpRequested;
    // Update is called once per frame
    void FixedUpdate()
    {
        var vel = rb.velocity;
        vel.x = _direction.x * speed;
        _canJump = groundCheck.IsGrounded();
        if (_canJump && _jumpRequested)
        {
            vel.y = jumpForce;
            _jumpRequested = false;
            _canJump = false;
        }
        
        rb.velocity = vel;
        
    }

    public override void Move(Vector2 direction)
    {
        _direction = direction;
    }

    public override void Jump()
    {
        Debug.Log(_canJump);
        if (_canJump)
        {
            _jumpRequested = true;
        }
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
}