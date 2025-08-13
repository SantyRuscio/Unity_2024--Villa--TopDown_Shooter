using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoStatic : MonoBehaviour
{
    private bool isFacingRight = true;
    public Animator animator;

    public float distanceToFllow;
    public float speed;

    public float hit = 34f;

    public float coolDown;
    private float _timer;

    public Transform player;

    private void Awake()
    {
        _timer = 0f; 
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (Vector3.Distance(transform.position, player.position) > distanceToFllow)
        {
            animator.SetFloat("Speed", 0);
            Patrol();
        }
        else
        {
            animator.SetFloat("Speed", 1);
            MoveToPlayer();
        }

        bool isPlayerRight = transform.position.x < player.position.x;
        Flip(isPlayerRight);
    }

    private void Flip(bool isPlayerRight)
    {
        if ((isFacingRight && !isPlayerRight))
        {
            isFacingRight = isPlayerRight;

            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        
    }

    private void Patrol()
    {
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerLife player = collision.gameObject.GetComponent<PlayerLife>();

        if (player != null && _timer >= coolDown)
        {
            player.HitEnemy(hit);
            _timer = 0;
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceToFllow);
    }
}