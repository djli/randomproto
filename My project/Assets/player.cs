using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject arrow;
    public AudioClip shootSound; // Assign your shooting sound here
    private ScoreManager scoreManager;

    private GameObject myArrow = null;
    private AudioSource audioSource;
    public static bool isActive = false;
    public static float timer = 30.0f;

    void Start()
    {
        // Initialize the AudioSource component
        audioSource = GetComponent<AudioSource>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
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
        timer -= Time.deltaTime;
        scoreManager.AddScore(0);
        if (Input.GetMouseButtonDown(0) && !isActive && timer > 0.0f)
        {
            // Instantiate arrow and set its direction
            isActive = true;
            GameObject myArrow = Instantiate(arrow, bowPosition, Quaternion.identity);
            myArrow.transform.right = direction;
            myArrow.GetComponent<Rigidbody2D>().AddForce(direction * 100);

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

    public static void noArrow()
    {
        isActive = false;
    }
}