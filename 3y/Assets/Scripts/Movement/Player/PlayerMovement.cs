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
    private bool _jumpRequested;
    
    private Vector2 _direction;
    private bool facingRight = true;

    public Animator animator;
    public ParticleSystem dust;
    // Update is called once per frame
    void FixedUpdate()
    {
        var vel = rb.velocity;
        vel.x = _direction.x * speed;
        //Animation
        animator.SetFloat("Speed", Mathf.Abs(vel.x));
        //Use BoxGroundCheck to know if the player is touching the ground.
        _canJump = groundCheck.IsGrounded();
        if (_jumpRequested && _canJump)
        {
            _jumpRequested = false;
            _canJump = false;
            vel.y = jumpForce;
            animator.SetBool("IsJumping", true);
        }

        if (_canJump)
        {
            animator.SetBool("IsJumping", false);
            
        }

        if (_isFalling && rb.velocity.y > 0)
        {
            vel.y *= .3f;
            //_isFalling = false;
        }
                
        if (vel.x > 0 && !facingRight)
        {
            Flip();
        }else if (vel.x < 0 && facingRight)
        {
            Flip();
        }

        _isFalling = false;
        rb.velocity = vel;
        
    }

    public override void Move(Vector2 direction)
    {
        _direction = direction;
        //MakeDust();
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

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        if (_canJump)
        {
            MakeDust();
        }
    }

    public override void Sit()
    {
        animator.SetBool("IsSitting", !animator.GetBool("IsSitting"));
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    private void MakeDust()
    {
        dust.Play();
    }
}