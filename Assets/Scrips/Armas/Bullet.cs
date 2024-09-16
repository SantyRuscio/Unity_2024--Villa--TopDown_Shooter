using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{

    public float velocidad;

    public float Damage = 50;

    //-------------------------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        Input.GetMouseButton(0);

        Vector2 Movement = new Vector2(1 * velocidad * Time.deltaTime, 0);
        transform.position = transform.position + (Vector3)Movement;
    }
  
    //-------------------------------------------------------------------------------------------------------------------------------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyLife enemyLife = collision.gameObject.GetComponent<EnemyLife>();

        if (enemyLife != null)
        {
            enemyLife.HitBullet(Damage);
            Destroy(gameObject);
        }
    }

}