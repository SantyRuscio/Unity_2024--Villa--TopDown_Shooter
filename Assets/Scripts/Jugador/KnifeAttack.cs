using System.Collections;
using UnityEngine;

public class KnifeAttack : MonoBehaviour
{
    public GameObject slashPrefab; 
    public Transform slashSpawnPoint; 
    public float attackDuration = 0.3f; 
    public float freezeDuration = 0.3f; 

    public AudioSource controlSonido;
    public AudioClip SonidoDeCuchillo;

    private bool isAttacking = false; 
    private MovimientoJugador movimientoJugador; 

    public Sprite holdingKnifeSprite; 
    private SpriteRenderer spriteRenderer; 

    private void Start()
    {
        
        movimientoJugador = GetComponent<MovimientoJugador>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    private void Update()
    {
        
        if (spriteRenderer.sprite == holdingKnifeSprite && !isAttacking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(PerformSlash());
            }

            if (Input.GetMouseButtonDown(1))
            {   
                StartCoroutine(FreezePlayer());
            }
        }
    }

    private IEnumerator PerformSlash()
    {
        isAttacking = true;

        if (movimientoJugador != null)
        {
            movimientoJugador.isFrozen = true;
        }

        controlSonido.PlayOneShot(SonidoDeCuchillo);

        GameObject slash = Instantiate(slashPrefab, slashSpawnPoint.position, slashSpawnPoint.rotation);

        Destroy(slash, attackDuration);

        yield return new WaitForSeconds(attackDuration);

        if (movimientoJugador != null)
        {
            movimientoJugador.isFrozen = false;
        }

        isAttacking = false;
    }

    private IEnumerator FreezePlayer()
    {
        isAttacking = true;

        if (movimientoJugador != null)
        {
            movimientoJugador.isFrozen = true;
        }

        yield return new WaitForSeconds(freezeDuration);

        if (movimientoJugador != null)
        {
            movimientoJugador.isFrozen = false;
        }

        isAttacking = false;
    }
}