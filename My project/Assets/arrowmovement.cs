using UnityEngine;

public class arrowmovement : MonoBehaviour
{
    public Rigidbody2D rb;

    // Reference to the ScoreManager
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        // Finding and referencing the ScoreManager in the scene
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(rb.velocity, transform.right);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 70 * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TargetSoundScript targetSoundScript = collision.gameObject.GetComponent<TargetSoundScript>();

        if (targetSoundScript != null)
        {
            targetSoundScript.PlayHitSound();
        }

        if (collision.gameObject.CompareTag("walls"))
        {
            player.noArrow();
            scoreManager.AddScore(0);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("yellow"))
        {
            //add 50 points
            player.noArrow();
            scoreManager.AddScore(50);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("red"))
        {
            //add 25 points
            player.noArrow();
            scoreManager.AddScore(25);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("blue"))
        {
            //add 10 points
            player.noArrow();
            scoreManager.AddScore(10);
            Destroy(this.gameObject);
        }
    }
}
