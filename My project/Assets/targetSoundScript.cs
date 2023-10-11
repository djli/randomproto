using UnityEngine;

public class TargetSoundScript : MonoBehaviour
{
    public AudioClip hitSound; // Drag your AudioClip here
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Add the AudioSource component if it's not already attached to the target
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = hitSound;
        audioSource.playOnAwake = false; // Prevents the sound from playing upon the game's start
    }

    public void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }
}