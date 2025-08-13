using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Credits;
    public AudioSource AudioSource;
    public AudioClip ClickClip;
    public AudioClip HoverClip;

    public SceneTransition sceneTransition; 

    public void StartGame()
    {
        SetClip(ClickClip);
        sceneTransition.FadeOutAndLoadScene("Barrio");
    }

    public void GoToMenu()
    {
        SetClip(ClickClip);
        SceneManager.LoadScene("MenuDeInicio");
    }

    public void OpenOptions()
    {
        SetClip(ClickClip);
        SceneManager.LoadScene("Controles");
    }

    public void ShowCredits()
    {
        Credits.SetActive(!Credits.activeInHierarchy);
    }

    public void ExitGame()
    {
        SetClip(ClickClip);
        Debug.Log("Saliendo del juego.");
        Application.Quit();
    }

    public void PlayButtonHoverSound()
    {
        SetClip(HoverClip);
        AudioSource.Play();
    }

    public void GoToTest()
    {
        SetClip(ClickClip);
        SceneManager.LoadScene("PruebaControles");
    }

    private void SetClip(AudioClip newClip)
    {
        AudioSource.clip = newClip;
    }
}
