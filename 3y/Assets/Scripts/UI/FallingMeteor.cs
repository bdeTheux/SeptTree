using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    protected Rigidbody2D rb => _rb;
    protected void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        int indexChosen = Random.Range(0, fallPoints.Length);
        target = fallPoints[indexChosen];
    }

    private void FixedUpdate()
    {
        
        spawnMeteor();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Instantiate(rb, spawnPoint);
        Destroy(rb);

    }

    //Randomly chose a fallPoint
    private void spawnMeteor()
    {
        
        //when rb.transform == fallpoint instanciate / destroy
        Vector2 dir = target.position - transform.position;
        Debug.Log(target);
        //rb.AddForce(dir.normalized * Time.deltaTime, ForceMode2D.Force);
        //transform.Translate(dir,Space.Self);
        rb.velocity = target.position - transform.position;
        
    }
    
}
