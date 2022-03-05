using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
/*
 * We will make randomly fall meteor to random spot at a random time(or each 5s)
 */
public class FallingMeteor : MonoBehaviour
{
    [SerializeField] private Transform[] fallPoints;
    [SerializeField] private Transform spawnPoint;
    
    private Transform target;
    private Rigidbody2D _rb;
    private int nb = 0;
    [SerializeField] private Object meteorObject;
    protected Rigidbody2D rb => _rb;

    protected void Start()
    {
        if (target) return;
        int i = 0;
        foreach (var spawn in GameObject.FindGameObjectsWithTag("Target"))
        {
            fallPoints[i] = spawn.transform;
            i++;
        }
        spawnPoint = GameObject.FindWithTag("Respawn").transform;
        int indexChosen = Random.Range(0, fallPoints.Length);
        target = fallPoints[indexChosen];
    }

    protected void Awake()
    {
        
        
        _rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        spawnMeteor();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (nb > 5)
        {
            
        }
        else
        {
            Debug.Log(spawnPoint.position);
            Instantiate(meteorObject, spawnPoint);
            Destroy(gameObject);
            
            nb++;
        }
        

    }

    //Randomly chose a fallPoint
    private void spawnMeteor()
    {
        
        //Vector2 dir = target.position - transform.position;
        Debug.Log(target);
        rb.velocity = target.position - transform.position;
        
    }
    
}
