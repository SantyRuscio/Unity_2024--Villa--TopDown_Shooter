using UnityEngine;

public class Slash : MonoBehaviour
{
    public float damage = 50f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemigos"))
        {
            EnemyLife enemyLife = collision.GetComponent<EnemyLife>();
            if (enemyLife != null)
            {
                enemyLife.TakeDamage(damage); 
            }
        }
    }
}