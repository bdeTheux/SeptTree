using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private LayerMask weakMask;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(gameObject.layer);
        if (weakMask == (weakMask | 1 << other.gameObject.layer))
        {
            Debug.Log("Ici");
            DealDamage(other.gameObject);
            Debug.Log("Go : " + gameObject + " ot = " + other.gameObject);
        }
        else
        {
            var body = other.attachedRigidbody;
            if (body)
            {
                Debug.Log("la");

                DealDamage(body.gameObject);
            }
            else
            {
                Debug.Log("d");

                DealDamage(other.gameObject);
            }
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("other" + other.gameObject.layer);
        Debug.Log("go" + gameObject.layer);

        if (playerMask == (playerMask | 1 << other.gameObject.layer))
        {
            Debug.Log("hit");
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

        
    }

    private void DealDamage(GameObject obj)
    {
        var life = obj.GetComponent<IDamageable>();
        life?.TakeDamage(damage);
        
    }
}
