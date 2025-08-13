using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaInterna : MonoBehaviour
{
    private bool dentroDelTrigger = false;
    public string NombreDelNivel = "";
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI textMeshProUGUI2;
    public Dianas dianaReferencia;

    public SceneTransition sceneTransition; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("estoy chocando con" + collision.gameObject);

        if (collision.gameObject.CompareTag("Player") && dianaReferencia.dianaDestruida == true)
        {
            dentroDelTrigger = true;
            Debug.Log("ACA ESTOY");

            if (textMeshProUGUI != null)
            {
                textMeshProUGUI.gameObject.SetActive(true);
            }

            ConsiguioLlave();
        }
        else
        {
            textMeshProUGUI2.gameObject.SetActive(true);
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
                textMeshProUGUI2.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        ConsiguioLlave();
    }

    private void ConsiguioLlave()
    {
        if (dentroDelTrigger == true && Input.GetKeyDown(KeyCode.E))
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
