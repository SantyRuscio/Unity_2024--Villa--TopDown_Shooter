//------------------------------------------
//              Santiago Ruscio & Tomas El drogas
//------------------------------------------


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private bool _medKitNear = false;

    public float maxLife = 100;
    private float _currentLife;

    private LifePickup _botequin;
    
//-------------------------------------------------------------------------------------------------------------------------------------------
    public void SetKitNear(LifePickup BotequinEnElPiso)
    {
        _botequin = BotequinEnElPiso;

        if(BotequinEnElPiso != null)
            Debug.Log(BotequinEnElPiso.name);
    }

//-------------------------------------------------------------------------------------------------------------------------------------------
    public void HitEnemy(float hit)
    {
        _currentLife = _currentLife - hit;
        Debug.Log("El enemigo te pego");

        ChecLife();
    }
 //-------------------------------------------------------------------------------------------------------------------------------------------

    private void ChecLife()
    {
        if (_currentLife > 0)
        {
            Debug.Log("Sigues vivo");
        }
        else
        {
            Debug.Log("-----------------------------------------------------------");
            Debug.Log("Moriste");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------
    public void TakeDamage(float damage)  // DAMAGE RECIBIDO ---- falta scrip del que hace la accion 
    {
        _currentLife = _currentLife - damage;

        if (_currentLife <= 0)
        {
            _currentLife = 0;
            Death();
        }
    }

 //--------------------------------------------------------------------------------------------------------------------------------------
    private void Death() //PANTALLA MUERTE
    {
        Debug.Log("Muertes");

    }

//-------------------------------------------------------------------------------------------------------------------------------------------
    private void Start()
    {
        _currentLife = maxLife;
    }

//-------------------------------------------------------------------------------------------------------------------------------------------
    private void Update()
    {
        CheckInput();
    }

//-------------------------------------------------------------------------------------------------------------------------------------------
    private void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.E) && _botequin != null)
        {
            GetHealth();
            Destroy(_botequin.gameObject);
        }
    }

//-------------------------------------------------------------------------------------------------------------------------------------------
    private void GetHealth()
    {
        _currentLife = maxLife;
    }
}