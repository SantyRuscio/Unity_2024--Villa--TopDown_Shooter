using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public GameObject textObject; 
    private bool isPlayerNearby = false; 
    private bool isTextVisible = false; 
    private bool isObjectActive = true;

    public AudioSource controlSonido;
    public AudioClip SonidoDeNota;

    private MovimientoJugador playerMovement; 

    void Start()
    {
        if (textObject != null)
        {
            textObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!isObjectActive) return; 

        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            controlSonido.PlayOneShot(SonidoDeNota);

            ToggleText(); 
        }

    }

    private void ToggleText()
    {
        if (textObject != null)
        {
            isTextVisible = !isTextVisible;
            textObject.SetActive(isTextVisible);

            if (playerMovement != null)
            {
                playerMovement.enabled = !isTextVisible;
            }
        }
    }

    private void ToggleObject()
    {
        isObjectActive = !isObjectActive;
        gameObject.SetActive(isObjectActive); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true; 
            playerMovement = other.GetComponent<MovimientoJugador>(); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false; 
        }
    }
}