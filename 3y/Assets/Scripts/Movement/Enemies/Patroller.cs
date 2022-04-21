using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MovementController
{
    [SerializeField] private Transform[] waypoints;
    private float speed = 5;
    private int target;

    private float distance;
    private bool facingRight = true;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        target = 0;
        //transform.LookAt(waypoints[target].position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, waypoints[target].position);
        if (distance < 1.5f)
        {
            target = (target+1) % waypoints.Length;
            
        }
        if (dir.x > 0 && !facingRight)
        {
            Flip();
        }else if (dir.x < 0 && facingRight)
        {
            Flip();
        }
        Patrol();
    }

    void Patrol()
    {
        dir = waypoints[target].position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        rb.AddForce(dir.normalized * speed * Time.deltaTime, ForceMode2D.Force);
        
    }

    public override void Move(Vector2 direction)
    {
        throw new System.NotImplementedException();
    }

    public override void Jump()
    {
        throw new System.NotImplementedException();
    }

    public override void Fall()
    {
        throw new System.NotImplementedException();
    }

    public override void Sit()
    {
        throw new System.NotImplementedException();
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Shrimp()
    {
        throw new NotImplementedException();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
}
