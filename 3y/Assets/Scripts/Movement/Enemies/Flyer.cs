using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Flyer : MonoBehaviour
{

    private Vector3 spawnPoint;
    [SerializeField] private float circleRadius;
    [SerializeField] private float speed;
    private Vector3 pos;
    private bool _facingRight;
    private void Awake()
    {
        spawnPoint = transform.position;

    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            GetRandomPos();
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if (_facingRight && pos.x > 0)
        {
            Flip();
        }else if (!_facingRight && pos.x < 0)
        {
            Flip();
        }
    }

    private void Move()
    {
        float dist = Vector3.Distance(transform.position, spawnPoint);
        if(dist>circleRadius)
        {
            pos = (spawnPoint - transform.position).normalized;
        }
        transform.Translate(pos * Time.deltaTime * speed);
    }
    private void GetRandomPos()
    {
        //pos = new Vector3(Random.Range(-2, 2),Random.Range(-2, 2));
        pos = Random.insideUnitCircle * 2f;
        pos = pos.normalized;
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(spawnPoint, circleRadius);
    }
    
    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
