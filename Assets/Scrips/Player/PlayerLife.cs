//------------------------------------------
//              Santiago Ruscio & Tomas El drogas
//------------------------------------------


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private bool _medKitNear = false;

    public float maxLife = 100;
    private float _currentLife;

//-------------------------------------------------------------------------------------------------------------------------------------------
    public void SetKitNear(bool NewState)
    {
        _medKitNear = NewState;
        Debug.Log(NewState);
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
        if(Input.GetKeyDown(KeyCode.E) && _medKitNear == true)
        {
            GetHealth();
        }
    }

//-------------------------------------------------------------------------------------------------------------------------------------------
    private void GetHealth()
    {
        _currentLife = maxLife;
    }
}