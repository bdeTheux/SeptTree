using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovementController
{
    
    [SerializeField] private int speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private BoxGroundCheck groundCheck;
    private bool _canJump;
    private bool _isFalling;

    private Vector2 _direction;

    private bool _jumpRequested;
    // Update is called once per frame
    void FixedUpdate()
    {
        var vel = rb.velocity;
        vel.x = _direction.x * speed;
        //Use BoxGroundCheck to know if the player is touching the ground.
        _canJump = groundCheck.IsGrounded();
        if (_jumpRequested && _canJump)
        {
            _jumpRequested = false;
            _canJump = false;
            vel.y = jumpForce;
            
        }

        if (_isFalling && rb.velocity.y > 0)
        {
            vel.y *= .3f;
            //_isFalling = false;
        }

        _isFalling = false;
        rb.velocity = vel;
        
    }

    public override void Move(Vector2 direction)
    {
        _direction = direction;
    }

    public override void Jump()
    {
        if (_canJump)
        {
            _jumpRequested = true;
        }
    }

    public override void Fall()
    {
        _isFalling = true;
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
}