using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float _currentLifeEnemy = 100;

    public void HitBullet(float Damage)
    {
        _currentLifeEnemy = _currentLifeEnemy - Damage;
        Debug.Log("El enemigo recibio damage");

        CheckLife();
    }

    private void CheckLife()
    {
        if (_currentLifeEnemy > 0)
        {
            Debug.Log("El enemigo sigue vivo");
        }
        else
        {
            Debug.Log("-------------------ENEMIGO MURIO----------------------------------------");
            Destroy(gameObject); 
        }
    }
}
