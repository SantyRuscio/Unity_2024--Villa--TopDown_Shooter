using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public float maxLife = 100;
    private float _currentLife;

    public AudioSource controlSonido;
    public AudioClip SonidoDamage;

    public GameObject gameOverTextPrefab;
    private GameObject gameOverTextInstance;

    private Collider2D playerCollider;
    private SpriteRenderer playerSprite;
    private Rigidbody2D playerRigidbody;
    private MovimientoJugador playerMovement;
    private Disparo playerShooting;
    private KnifeAttack playerKnifeAttack; 

    void Start()
    {
        _currentLife = maxLife;
        playerCollider = GetComponent<Collider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<MovimientoJugador>();
        playerShooting = GetComponent<Disparo>();
        playerKnifeAttack = GetComponent<KnifeAttack>(); 

        if (gameOverTextPrefab != null)
        {
            gameOverTextPrefab.SetActive(false);
        }
    }

    //------------------------------------------------------//
    public void HitEnemy(float hit)
    {
        _currentLife -= hit;

        controlSonido.PlayOneShot(SonidoDamage);

        Debug.Log("El enemigo te pegó");

        CheckLife();
    }

    //------------------------------------------------------//
    private void CheckLife()
    {
        if (_currentLife > 0)
        {
            Debug.Log("Sigues vivo");
        }
        else
        {
            Debug.Log("Moriste");
            Death();
        }
    }

    //------------------------------------------------------//
    private void Death()
    {
        if (playerCollider != null) playerCollider.enabled = false;
        if (playerSprite != null) playerSprite.enabled = false;

        if (gameOverTextPrefab != null)
        {
            gameOverTextPrefab.SetActive(true);
        }

        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.isKinematic = true;
        }

        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        if (playerShooting != null)
        {
            playerShooting.enabled = false;
        }

        if (playerKnifeAttack != null)
        {
            playerKnifeAttack.enabled = false; 
        }

        StartCoroutine(WaitForRestart());
    }

    //------------------------------------------------------//
    private IEnumerator WaitForRestart()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            }
            yield return null;

            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("MenuDeInicio");
                break;
            }
            yield return null;
        }
    }
}
