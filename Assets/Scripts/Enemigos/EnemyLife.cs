using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float Maxlife = 100f;
    private float CurrentLife;

    public AudioSource controlSonido;
    public AudioClip SonidoDeDamage;
    public GameObject bloodParticlePrefab; 

    private List<GameObject> bloodParticlesList = new List<GameObject>(); 

    private void Start()
    {
        CurrentLife = Maxlife;
    }

    public void TakeDamage(float damage)
    {
        if (controlSonido != null && SonidoDeDamage != null) 
        {
            controlSonido.PlayOneShot(SonidoDeDamage);
        }

        CurrentLife -= damage;

        
        if (bloodParticlePrefab != null)
        {
            Vector3 spawnPosition = transform.position + new Vector3(0, 0, -0.5f); 
            GameObject bloodParticles = Instantiate(bloodParticlePrefab, spawnPosition, Quaternion.identity, transform); 
            bloodParticlesList.Add(bloodParticles); 
            Debug.Log("Partículas de sangre instanciadas en posición: " + bloodParticles.transform.position);
        }
        else
        {
            Debug.Log("bloodParticlePrefab no asignado");
        }

        CheckLife();
    }

    private void CheckLife()
    {
        if (CurrentLife <= 0)
        {
            Death();
        }
        else
        {
            Debug.Log("Sigue Vivo");
        }
    }

    private void Death()
    {
        
        foreach (GameObject bloodParticles in bloodParticlesList)
        {
            if (bloodParticles != null)
            {
                Destroy(bloodParticles);
            }
        }

        
        Destroy(gameObject);
    }
}
