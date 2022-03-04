using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int initialHealth;
    [SerializeField] private int currentHealth;
    
    //Init Health
    private void OnEnable()
    {
        currentHealth = initialHealth;
    }

    //Take damage
    public void TakeDamage(int damage)
    {
        Debug.Log("Aie");
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    //Die
    private void Die()
    {
        Debug.Log("Mort");
        //destroy with time
        Destroy(gameObject,0.6f);
    }
    
}
