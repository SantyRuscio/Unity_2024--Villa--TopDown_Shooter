using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public Sprite holdingWeaponSprite;
    public GameObject bulletPrefab;
    public Transform firePoint;
    private SpriteRenderer spriteRenderer;

    public AudioSource controlSonido;
    public AudioClip SonidoDisparo;

    public float shootingCooldown = 0.5f; 
    private float lastShotTime = 0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            if (Time.time - lastShotTime >= shootingCooldown)
            {
                if (spriteRenderer.sprite == holdingWeaponSprite)
                {
                    Shoot();
                }
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = firePoint.position;
        bullet.transform.right = firePoint.right;

        controlSonido.PlayOneShot(SonidoDisparo);

        lastShotTime = Time.time;
    }
}