using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dianas : MonoBehaviour
{
    public AudioSource controlSonido;
    public AudioClip SonidoDeDiana;
    public SpriteRenderer SpriteRenderer;

    public bool dianaDestruida = false;

    private bool shoted;
    float timer = 0;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(shoted == false && collision.CompareTag("Player") )
        {
            controlSonido.PlayOneShot(SonidoDeDiana);
            Destroy(SpriteRenderer);
            shoted = true;

            dianaDestruida = true;
        }
    }

    private void Update()
    {
        if (shoted == true )
        { 
            timer = timer + Time.deltaTime;

            if (timer >= SonidoDeDiana.length)
            {
                Destroy(gameObject);  
            }
        }
    }

}
