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
    [SerializeField] private GameManagerProxy proxy;
    
    //Init Health
    private void OnEnable()
    {
        currentHealth = initialHealth;
        _isPlayer = slider != null;
    }

    //Take damage
    public void TakeDamage(int damage)
    {
        if (gameObject == null) return;
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if(_isPlayer)
                slider.value = slider.minValue;
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
        if(_isPlayer)
        {
            proxy.DieMenu();
        }
        //destroy with time
        //Destroy(gameObject,0.6f);
    }
    
}
