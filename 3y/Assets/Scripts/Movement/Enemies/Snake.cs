using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool facingRight = true;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;

    [SerializeField] private float circleRadius;
    [SerializeField] private float wallCircleRadius;

    
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    private bool isWall;
    private float speed = 2;
    private int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, circleRadius, groundLayer);
        isWall = Physics2D.OverlapCircle(wallCheck.position, wallCircleRadius, groundLayer);

    }

    private void Move()
    {
        if (!isGrounded || isWall)
        {
            Flip();
        }
        var vel = new Vector2(dir * speed, rb.velocity.y);
        rb.velocity = vel.normalized * 2;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        dir *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheck.position, wallCircleRadius);

    }
}
