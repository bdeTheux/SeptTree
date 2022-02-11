using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGroundCheck : MonoBehaviour
{
    //private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private float groundCheckRadius = 0.3f;

    public bool IsGrounded()
    {   
       
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
