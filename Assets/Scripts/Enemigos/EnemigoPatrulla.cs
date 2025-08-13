using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPatrulla : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waitTime;
    [SerializeField] private float speed;

    private bool isWaiting = false;
    private bool isFacingRight = true;
    public float distanceToFllow;
    private bool _playerOnSight;
    private int currentWaypoint;
    private float _timer;
    public float coolDown;
    public float hit = 34f;
    public Transform player;
    Animator animator;

    private void Awake()
    {
        _timer = 0f; 
    }

    void Update()
    {
        CheckPlayerDistance();

        if (_playerOnSight)
        {
            MoveToPlayer();
        }
        else
        {
            Patrullar();
        }
    }

    void CheckPlayerDistance()
    {
        if (Vector3.Distance(transform.position, player.position) > distanceToFllow)
        {
            _playerOnSight = false;
        }
        else
        {
            _playerOnSight = true;
        }
    }

    void MoveToPlayer()
    {
        Vector2 direction = player.position - transform.position;
        Flip(direction.x > 0);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        
    }

    void Patrullar()
    {
        if (transform.position != waypoints[currentWaypoint].position)
        {
            Vector2 direction = waypoints[currentWaypoint].position - transform.position;
            Flip(direction.x > 0);
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        }
        else if (!isWaiting)
        {
            StartCoroutine(Wait());
        }
    }

    void Flip(bool isTargetRight)
    {
        if (isFacingRight != isTargetRight)
        {
            isFacingRight = isTargetRight;

            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWaypoint++;

        if (currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }
        isWaiting = false;
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