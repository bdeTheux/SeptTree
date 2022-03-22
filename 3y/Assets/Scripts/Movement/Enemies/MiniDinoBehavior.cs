using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/*
 * They will follow the player when trigger 4 follower max
 */
public class MiniDinoBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private int speed = 6;
    [SerializeField] private int maxFollower = 4;
    [SerializeField] private static int cmpFollower;
    private bool _isPlayerSitting;
    [SerializeField] private LayerMask playerMask;
    private bool _isFollowing;
    private Transform player;
    public Animator animator;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (player == null)
        {
            _isFollowing = false;
        }
        if (_isFollowing)
        {
            Run();
        }
    }

    private void Run()
    {
        Vector2 dir;
        if (cmpFollower == maxFollower)
        {
            //Run away
            //tmp
            dir = (player.position - transform.position);

        }
        else
        {
            //Follow
            dir = (player.position - transform.position);
            dir.x += Random.Range(2, 5);
            rb.MovePosition((Vector2)transform.position + (dir * Time.deltaTime));
        }
        //Animation
        var vel = rb.velocity;
        vel.x = dir.x * speed;
        animator.SetFloat("Speed", Mathf.Abs(vel.x));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerMask == (playerMask | 1 << other.gameObject.layer))
        {
            if (cmpFollower == maxFollower)
            {
                Debug.Log("A Runner !");
            }
            else
            {
                if (!_isFollowing)
                {
                    cmpFollower++;
                }
                player = other.attachedRigidbody.transform;
                _isFollowing = true; 
            }
        }
    }
}
