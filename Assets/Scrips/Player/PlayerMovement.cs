using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;

    private bool _arma = false;

    private int _currentAmmunation = 0;

    public Transform shootPoint;
    public Bullet bulletPrefab;

//-------------------------------------------------------------------------------------------------------------------------------------------
    public void GetPistol()
    {
        if(_arma == false)
        {
            _arma = true;
        }

        _currentAmmunation = _currentAmmunation + 10;
    }

//-------------------------------------------------------------------------------------------------------------------------------------------
    private void Update()
    {
        InputChecker();
    }

//-------------------------------------------------------------------------------------------------------------------------------------------
    private void InputChecker()
    {
        MovePlayer();

        CheckShootInput();
    }

//-------------------------------------------------------------------------------------------------------------------------------------------
    private void MovePlayer()
    {
        Vector2 Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position = transform.position + (Vector3)Movement * Time.deltaTime * speed;
    }

//-------------------------------------------------------------------------------------------------------------------------------------------
    private void CheckShootInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_arma == true)
            {
                if(_currentAmmunation > 0)
                {
                    Shoot();
                }
                else
                {
                    Debug.Log("No tiene balas");
                }
            }
            else
            {
                Debug.Log("No tiene arma");
            }
        }
    }

//-------------------------------------------------------------------------------------------------------------------------------------------
    private void Shoot()
    {
        Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation);

        Debug.Log("Disparo");

        _currentAmmunation = _currentAmmunation - 1;

        if(_currentAmmunation < 0)
        {
            _currentAmmunation = 0;
        }
    }
}