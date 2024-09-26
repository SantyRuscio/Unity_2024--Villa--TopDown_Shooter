using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Patrulla : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waitTime;
    [SerializeField] private float speed;
    private bool isWaiting = false;
    public float distanceToFllow;
    private bool _playerOnSight;
    private int currentWaypoint;
    public Transform player;
    private float _timer;
    public float coolDown;
    public float hit = 34f;

    void Update()
    {
        CheckPlayerDistance();

        if (_playerOnSight)
        {
            MoveToPlayer();
        }
        else
        {
            patrullar();
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
      transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
      Debug.Log("Te persigue");
    }

    void patrullar()
    {
        if (transform.position != waypoints[currentWaypoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        }
        else if (!isWaiting)
        {
            StartCoroutine(Wait());
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
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceToFllow);
    }
}