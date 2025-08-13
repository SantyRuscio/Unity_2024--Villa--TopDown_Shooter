using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPick : MonoBehaviour
{

    private bool shoted;
    float timer = 0;

    public AudioSource controlSonido;
    public AudioClip SonidoDeDiana;

    public Sprite newCharacterSprite;
    public SpriteRenderer SpriteRenderer;
    public BoxCollider BoxCollider;

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && shoted == false)
        {
            SpriteRenderer playerSpriteRenderer = other.GetComponent<SpriteRenderer>();

            if (playerSpriteRenderer != null)
            {
                playerSpriteRenderer.sprite = newCharacterSprite;
            }
            
            controlSonido.PlayOneShot(SonidoDeDiana);
            Destroy(SpriteRenderer);
            Destroy(BoxCollider);

            shoted = true;
        }


    }
    private void Update()
    {
        if (shoted == true)
        {
            timer = timer + Time.deltaTime;

            if (timer >= SonidoDeDiana.length)
            {
                Destroy(gameObject);
            }
        }
    }

}
