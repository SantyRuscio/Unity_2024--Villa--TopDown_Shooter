using System.Collections;
using System.Collections.Generic;
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceToFllow);
    }
}