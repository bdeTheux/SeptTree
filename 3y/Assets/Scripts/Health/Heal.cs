using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerMask == (playerMask | 1 << other.gameObject.layer))
        {
            Debug.Log("Ici");
            HealUp(other.gameObject);
            Destroy(gameObject);
        }
        
        
    }
    
    private void HealUp(GameObject obj)
    {
        var life = obj.GetComponent<IDamageable>();
        life?.Heal(2);
        
    }
}
