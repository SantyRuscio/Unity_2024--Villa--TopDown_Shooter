using UnityEngine;

public class PickupPistola : MonoBehaviour
{

//-------------------------------------------------------------------------------------------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();

        if(player != null)
        {
            player.GetPistol();
            Destroy(gameObject);
        }
    }
}