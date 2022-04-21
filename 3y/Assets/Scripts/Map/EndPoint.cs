using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameManagerProxy proxy;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (playerLayer == (playerLayer | 1 << other.gameObject.layer))
        {
            Destroy(GameObject.FindWithTag("Musique"));
            proxy.NextLevel();
        }
    }
}
