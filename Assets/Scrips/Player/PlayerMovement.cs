using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Camera mainCamera ;

    private bool _arma = false;

    private int _currentAmmunation = 0;

    public float speed = 3f;
    public float _vida = 3f;

    public Transform shootPoint;
    public Bullet bulletPrefab;
    //-------------------------------------------------------------------------------------------------------------------------------------------
    private void Start()
    {
       
        if  (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

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
        //Se llama en el update

        MovePlayer();
        RotatePlayer();
        CheckShootInput();
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------
    private void RotatePlayer()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        Vector3 lookAtDireccion = mouseWorldPosition - transform.position;
        transform.right = lookAtDireccion;
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