using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int initialHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private Slider slider;
    private bool _isPlayer;
    //Init Health
    private void OnEnable()
    {
        currentHealth = initialHealth;
        _isPlayer = slider != null;
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

        if (_isPlayer)
        {
            if (currentHealth < slider.minValue)
            {
                currentHealth = (int)slider.minValue;
            }
            slider.value = currentHealth;
        }
    }

    public void Heal(int health)
    {
        if ((currentHealth+health) > slider.maxValue)
        {
            currentHealth = (int)slider.maxValue;
            slider.value = slider.maxValue;
        }
        else
        {
            currentHealth += health;
            slider.value = currentHealth;
        }
    }
    
    //Die
    private void Die()
    {
        if (!_isPlayer)
        {
            Destroy(transform.parent.gameObject);
        }
        Debug.Log("Mort");
        //destroy with time
        Destroy(gameObject,0.6f);
    }
    
}
