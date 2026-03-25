using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
    public static BackgroundMusicPlayer Instance;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip backgroundMusic;
    public bool playOnStart = true;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (audioSource != null)
        {
            audioSource.loop = true;

            if (backgroundMusic != null)
            {
                audioSource.clip = backgroundMusic;
            }

            if (playOnStart && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
