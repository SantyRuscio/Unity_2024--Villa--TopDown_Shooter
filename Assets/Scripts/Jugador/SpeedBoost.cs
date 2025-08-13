using System.Collections;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    
    private SpriteRenderer SpriteRenderer;
    private BoxCollider BoxCollider;
    private bool picked;

    public float boostAmount = 5f; 
    public float boostDuration = 3f;

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider = GetComponent<BoxCollider>();
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && picked == false)
        {
            MovimientoJugador playerMovement = other.GetComponent<MovimientoJugador>(); 
            if (playerMovement != null)
            {
                StartCoroutine(ApplySpeedBoost(playerMovement));

                Destroy(SpriteRenderer);
                Destroy(BoxCollider);

                picked = true;
            }
        }
    }

    private void Update()
    {
    }

    private IEnumerator ApplySpeedBoost(MovimientoJugador playerMovement)
    {
        float originalSpeed = playerMovement.speed;

        playerMovement.speed += boostAmount;

        gameObject.SetActive(false);

        yield return new WaitForSeconds(boostDuration);

        playerMovement.speed = originalSpeed;

        Destroy(gameObject);
    }
}