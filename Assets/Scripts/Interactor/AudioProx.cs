using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioProx : MonoBehaviour
{
    private AudioSource audioSource;
    public int contador;

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            contador++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }

    private void Update()
    {
        if (contador == 4)
        {
            Destroy(audioSource);
        }
        
    }
}
