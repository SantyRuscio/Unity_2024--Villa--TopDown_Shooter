using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAi : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float timeBetweenShoots;
    private bool _playerOnSight;
    public float distanceToShoot;
    public Transform player;

    float timer = 0;

    private void Update()
    {
        CheckPlayerDistance();

        if (_playerOnSight)
        {
            timer = timer + Time.deltaTime;

            if(timer >= timeBetweenShoots)
            {
                Shoot();
                timer = 0;
            }
        }
    }


    void CheckPlayerDistance()
    {
        if (Vector3.Distance(transform.position, player.position) > distanceToShoot)
        {
            _playerOnSight = false;
        }
        else
        {
            _playerOnSight = true;
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceToShoot);
    }
}
