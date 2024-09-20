using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction;

    public float velocidad;
    public float lifeSpan = 10f;

    public float Damage = 50;

    //-------------------------------------------------------------------------------------------------------------------------------------------
    public void SetDirection(Vector3 direction)
    {
        // reciibo la dirfecion que tengo que ir y la guardo para suarla
        _direction = direction; 
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------
    private void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------
    private void Update()
    {
        // voy hacia la direccion
        transform.position = transform.position + _direction * velocidad * Time.deltaTime;
    }
  
    //-------------------------------------------------------------------------------------------------------------------------------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyLife enemyLife = collision.gameObject.GetComponent<EnemyLife>();

        if (enemyLife != null)
        {
            enemyLife.HitBullet(Damage);
        }

        // Que se destruya con cuaolquier colision
        Destroy(gameObject); 
    }
}