using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject arrow;
    public AudioClip shootSound; // Assign your shooting sound here

    private GameObject myArrow = null;
    private AudioSource audioSource;

    void Start()
    {
        // Initialize the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Add the AudioSource component if not already attached to the player GameObject
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = cursorPosition - bowPosition;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0) && myArrow == null)
        {
            // Instantiate arrow and set its direction
            GameObject arrowIns = Instantiate(arrow, bowPosition, Quaternion.identity);
            arrowIns.transform.right = direction;
            arrowIns.GetComponent<Rigidbody2D>().AddForce(direction * 100);

            // Play the shooting sound effect
            PlayShootSound();
        }
    }

    // Method to play shooting sound effect
    private void PlayShootSound()
    {
        if (shootSound != null && audioSource != null)
        {
            audioSource.clip = shootSound; // Set the clip to shootSound
            audioSource.Play(); // Play the shooting sound effect
        }
        else
        {
            Debug.LogError("Shoot sound or AudioSource component is missing!");
        }
    }
}