using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private LayerMask weakMask;
    private float godLikeTimer = 3f;
    private bool godLike;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (weakMask == (weakMask | 1 << other.gameObject.layer))
        {
            DealDamage(other.gameObject);
        }
        else
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
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!godLike)
        {
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
                StartCoroutine(GodLike());

            }
            
        }
        
    }

    private void DealDamage(GameObject obj)
    {
        var life = obj.GetComponent<IDamageable>();
        life?.TakeDamage(damage);
    }

    private IEnumerator GodLike()
    {
        godLike = true;
        yield return new WaitForSeconds(godLikeTimer);
        godLike = false;
    }
}
