using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractorPuerta : MonoBehaviour
{
    private bool dentroDelTrigger = false;
    public string NombreDelNivel = "";
    public TextMeshProUGUI textMeshProUGUI;

    public SceneTransition sceneTransition; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dentroDelTrigger = true;

            if (textMeshProUGUI != null)
            {
                textMeshProUGUI.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dentroDelTrigger = false;

            if(textMeshProUGUI != null)
            {
                textMeshProUGUI.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (dentroDelTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (sceneTransition != null)
            {
                sceneTransition.FadeOutAndLoadScene(NombreDelNivel); 
            }
            else
            {
                Debug.LogError("SceneTransition no está asignado");
            }
        }
    }
}
