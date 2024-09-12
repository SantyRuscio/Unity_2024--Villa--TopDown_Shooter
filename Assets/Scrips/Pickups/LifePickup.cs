using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour
{
//-------------------------------------------------------------------------------------------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerLife playerLife = collision.gameObject.GetComponent<PlayerLife>();

        if (playerLife != null)
        {
            playerLife.SetKitNear(this);
        }
    }

//-------------------------------------------------------------------------------------------------------------------------------------------
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerLife playerLife = collision.gameObject.GetComponent<PlayerLife>();

        if (playerLife != null)
        {
            playerLife.SetKitNear(null);
        }
    }
}