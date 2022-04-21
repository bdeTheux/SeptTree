using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGroundCheck : MonoBehaviour
{
    //private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform roofCheck;
    private float groundCheckRadius = 0.3f;
    [SerializeField] private float roofCheckRadius = 0.3f;


    public bool IsGrounded()
    {   
       
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    
    public bool IsRoofed()
    {   
       
        return Physics2D.OverlapCircle(roofCheck.position, roofCheckRadius, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        //Gizmos.DrawWireSphere(roofCheck.position, roofCheckRadius);
    }
}
