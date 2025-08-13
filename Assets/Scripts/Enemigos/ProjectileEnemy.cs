using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    [SerializeField]public float speed;
    private Transform player;
    private Rigidbody2D rb;

    public float hit;

    public LayerMask layermask;

    void Start()
    {
        player = FindObjectOfType<PlayerLife>().transform;
        rb = GetComponent<Rigidbody2D>();

        LaunchProjectile();
    }

    private void LaunchProjectile()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        rb.velocity = directionToPlayer * speed;
        StartCoroutine(DestroyProjectile());
    }
    IEnumerator DestroyProjectile()
    {
        float destroyTime = 5f;
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerLife player = collision.gameObject.GetComponent<PlayerLife>();

            if (player != null)
            {
                player.HitEnemy(hit);
               
            }
        
        Destroy(gameObject);
    }
}
