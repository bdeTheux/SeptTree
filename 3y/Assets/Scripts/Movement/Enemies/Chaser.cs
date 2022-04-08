using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is a script for the enemies that will follow the player
 * by default they idle
 */
public class Chaser : MovementController
{
    private int speed = 0;
    private int jumpPower = 0;
    private bool isChasing;
    private bool _canMove;

    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private LayerMask GroundMask;
    private Vector2 dir;
    [SerializeField] private BoxGroundCheck groundCheck;
    private bool _canJump;

    // Start is called before the first frame update
    void Start()
    {
        isChasing = false;
    }

    private void FixedUpdate()
    {
        _canJump = groundCheck.IsGrounded();
        if (player == null)
        {
            isChasing = false;
        }
        if (isChasing)
        {
            dir = player.position - transform.position;
            Move(dir);
        }
        //if ground jump || void
        LayerCheck();

        //Flip
        
    }

    public override void Move(Vector2 direction)
    {
        //animator speed
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        rb.AddForce(direction.normalized * speed * Time.deltaTime, ForceMode2D.Force);
    }

    public override void Jump()
    {
        rb.AddForce(new Vector2(dir.x,0f)*jumpPower, ForceMode2D.Impulse);
    }

    private void LayerCheck()
    {
        if (Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 0f), 50f, GroundMask))
        {
            if (_canJump)
            {
                Jump();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (playerMask == (playerMask | 1 << other.gameObject.layer))
        {
            isChasing = true;
        }
    }


    public override void Fall()
    {
        throw new NotImplementedException();
    }

    public override void Sit()
    {
        throw new NotImplementedException();
    }

    public override void Attack()
    {
        throw new NotImplementedException();
    }
}
