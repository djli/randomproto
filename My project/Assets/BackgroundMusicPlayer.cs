using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip musicClip; // Assign your music clip here in the Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing from this game object. Adding one.");
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = musicClip; // Set the audio clip in the AudioSource
        audioSource.loop = true; // Set the AudioClip to loop
        audioSource.playOnAwake = true; // Play the AudioClip on start

        // Play the music
        audioSource.Play();
    }
}
