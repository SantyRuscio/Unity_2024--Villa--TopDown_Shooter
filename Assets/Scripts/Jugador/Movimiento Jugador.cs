using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public bool moving = false;
    public float speed = 5.0f;
    public bool isFrozen = false; 

    void Update()
    {
        if (!isFrozen) 
        {
            movement();
        }
    }

    void movement()
    {
        Vector2 Movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.position = transform.position + (Vector3)Movement * Time.deltaTime * speed;
    }
}