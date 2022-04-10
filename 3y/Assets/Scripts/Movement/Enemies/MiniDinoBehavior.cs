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
    [SerializeField] private int maxFollower = 2;
    [SerializeField] private static int cmpFollower;
    private bool _isPlayerSitting;
    [SerializeField] private LayerMask playerMask;
    private bool _isFollowing;
    private bool _isARunner;
    private Rigidbody2D player;
    public Animator animator;
    private bool _isIn = false;
    private bool _facingRight;
    Animator _playerAnimator;
    //Jump
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;

    [SerializeField] private float circleRadius;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    private bool isWall;

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
        if (_isFollowing || _isARunner)
        {
            if (!_isARunner)
            {
                if (_facingRight && player.position.x > transform.position.x)
                {
                    Flip();
                }else if (!_facingRight && player.position.x < transform.position.x)
                {
                    Flip();
                }
                Run();
            }
            else
            {
                if (_facingRight && player.position.x < transform.position.x)
                {
                    Flip();
                }else if (!_facingRight && player.position.x > transform.position.x)
                {
                    Flip();
                }
                Run();
            }
            
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, circleRadius, groundLayer);
        isWall = Physics2D.OverlapCircle(wallCheck.position, circleRadius, groundLayer);
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheck.position, circleRadius);

    }

    private void Run()
    {
        Vector2 dir;
        if (cmpFollower == maxFollower && !_isFollowing)
        {
            //Run away
            //tmp
            Debug.Log("RUNNNNN");
            if (player.position.x >= transform.position.x)
            {
                dir = (player.transform.position - transform.position);
            }
            else
            {
                dir = (transform.position - player.transform.position);
            }
            
            if (isWall)
            {
                dir += Vector2.up* 6f;
                transform.Translate(dir * Time.deltaTime);

            }
            else
            {
                transform.Translate( dir *Time.deltaTime);

            }
            

        }
        else
        {
            //animation ---
            if (_playerAnimator.GetBool("IsSitting"))
            {
                animator.SetBool("IsSitting", true);
            }
            else
            {
                animator.SetBool("IsSitting", false);
            }
            animator.SetBool("IsFollowing", true);
            // -----
            
            //Follow
            if (player.velocity.x < 0.3f && _isIn)
            {
                dir = transform.position;
            }
            else
            {
                dir = (player.transform.position - transform.position);
                //dir.x += Random.Range(2, 5);
                
                //rb.MovePosition((Vector2)transform.position + (dir * Time.deltaTime));
                transform.Translate(dir*Time.deltaTime);
            }

        }
        //Animation
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.normalized.x * speed));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerMask == (playerMask | 1 << other.gameObject.layer))
        {
            ChooseType(other);
        }
    }

    private void ChooseType(Collider2D other)
    {
        //Get the player body
        player = other.attachedRigidbody;
        if (cmpFollower == maxFollower)
        {
            Debug.Log("A Runner !");
            _isARunner = true;
        }
        else
        {
            if (!_isFollowing)
            {
                cmpFollower++;
            }
            _playerAnimator = player.gameObject.GetComponent<Animator>();
            _isFollowing = true; 
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (playerMask == (playerMask | 1 << other.gameObject.layer))
        {
            _isIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (playerMask == (playerMask | 1 << other.gameObject.layer))
        {
            _isIn = false;
        }
    }
    
    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
