using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isFacingRight = true;

    public float distanceToFllow;
    public float speed;

    public float hit = 34f;

    public float coolDown;
    private float _timer;

    public Transform player;

    private void Awake()
    {
        _timer = coolDown;
    }

    void Update()
    {
        _timer = _timer + Time.deltaTime;

        if (Vector3.Distance(transform.position, player.position) > distanceToFllow)
        {
            Patrol();
        }
        else
        {
            MoveToPlayer();
        }

        bool isPlayerRight = transform.position.x < player.position.x;
        Flip(isPlayerRight);
    }

    private void Flip(bool isPlayerRight)
    {
        if ((isFacingRight && !isPlayerRight))
        {

        }
    }

    private void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        Debug.Log("Te persigue");
    }

    private void Patrol()
    {
        Debug.Log("Patrolando");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerLife player = collision.gameObject.GetComponent<PlayerLife>();

        if (player != null && _timer >= coolDown)
        {
            player.HitEnemy(hit);
            _timer = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceToFllow);
    }
}