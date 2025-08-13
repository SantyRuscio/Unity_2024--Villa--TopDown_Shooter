using UnityEngine;

public class KnifePickup : MonoBehaviour
{
    private bool shoted;
    float timer = 0;

    public AudioSource controlSonido;
    public AudioClip SonidoDeCuchi;

    public Sprite playerWithKnifeSprite;
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
                playerSpriteRenderer.sprite = playerWithKnifeSprite;
            }

            controlSonido.PlayOneShot(SonidoDeCuchi);
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

            if (timer >= SonidoDeCuchi.length)
            {
                Destroy(gameObject);
            }
        }
    }
}