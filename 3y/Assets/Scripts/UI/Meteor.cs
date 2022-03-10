using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Meteor : MonoBehaviour
{
    private Rigidbody2D _rb; 
    protected Rigidbody2D rb => _rb;
    private Transform target;
    protected void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }
    public void Start()
    {
        
        target = GameObject.FindWithTag("Target").transform;
        //target.position = (Vector2)target.position + Random.insideUnitCircle * 15;
        
    }

    public void FixedUpdate()
    {
        rb.velocity = target.position - transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy(this.gameObject);
    }

    
}
