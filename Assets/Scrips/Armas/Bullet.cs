using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocidad;

    public float danio;

//-------------------------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        Input.GetMouseButton(0);
        Vector2 Movement = new Vector2(1 * velocidad * Time.deltaTime, 0);
        transform.position = transform.position + (Vector3)Movement;
    }
}