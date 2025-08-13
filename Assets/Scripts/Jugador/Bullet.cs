using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float Damage = 34f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            EnemyLife enemy = collision.GetComponent<EnemyLife>();

            if (enemy != null)
            {
                Debug.Log("BALAAAA");
                enemy.TakeDamage(Damage);
            }
        }

        Destroy(gameObject);
    }
}
