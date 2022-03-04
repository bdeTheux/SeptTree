using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var body = other.attachedRigidbody;
        if (body)
        {
            DealDamage(body.gameObject);
        }
        else
        {
            DealDamage(other.gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        var body = other.rigidbody;
        if (body)
        {
            DealDamage(body.gameObject);
        }
        else
        {
            DealDamage(other.gameObject);
        }
    }

    private void DealDamage(GameObject obj)
    {
        var life = obj.GetComponent<IDamageable>();
        life?.TakeDamage(damage);
        
    }
}
