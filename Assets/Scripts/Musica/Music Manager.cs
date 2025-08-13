using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip gameMusic1;
    public AudioClip gameMusic2;
    public AudioClip gameMusic3;
    public AudioClip gameMusic4;
    public AudioClip winMusic;
    public AudioClip barrioMusic;

    private AudioSource audioSource;

    private static MusicManager instance;

    private void Awake()
    {
       
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        
        DontDestroyOnLoad(gameObject);

      
        audioSource = GetComponent<AudioSource>();

        audioSource.volume = 0.1f; 
    }

    private void OnEnable()
    {
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "MenuDeInicio":
                PlayMusic(menuMusic);
                break;
            case "Barrio":
            case "Barrio 1":
            case "Barrio 2":
            case "Barrio 3":
                PlayMusic(barrioMusic);
                break;
            case "InteriorCasa1":
                PlayMusic(gameMusic1);
                break;
            case "InteriorCasa2":
                PlayMusic(gameMusic2);
                break;
            case "InteriorCasa3":
                PlayMusic(gameMusic3);
                break;
            case "InteriorCasa4":
                PlayMusic(gameMusic4);
                break;
            case "Persecusion":
                PlayMusic(gameMusic);
                break;
            case "controles":
                PlayMusic(menuMusic);
                break;
            case "Win":
                PlayMusic(winMusic);
                break;
        }
    }

    public void PlayMusic(AudioClip clip)
    {
       
        if (audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}