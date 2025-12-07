using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraSnap : MonoBehaviour
{
    public float moveSpeed = 5f;          // Keyboard movement speed
    public float touchSensitivity = 0.01f; // Touch movement sensitivity

    public AudioSource cameraAudioSource;   // Plays the sound
    public AudioClip cameraFlashSound;      // The actual sound file


    public float captureRadius = 0.5f;    // Radius around screen center to detect Cheese Creatures
    public LayerMask cheeseCreatureLayer; // Layer for Cheese Creature detection
    public int scorePerCatch = 10;        // Score for each Cheese Creature captured

   
    public Text scoreText;                // UI Text to show score
    public Image flashOverlay;            // White fullscreen image for flash effect

    private int score = 0;                // Current score (ironic cause i couldnt get scoreboard working)

    public GameOverManager gameOverManager;


    void Start()
    {
        // Initialize score UI
        if (scoreText != null)
            scoreText.text = "Score: 0";

        // Make flash overlay invisible at start
        if (flashOverlay != null)
            flashOverlay.color = new Color(1, 1, 1, 0f);
    }

    void Update()
    {
        HandleMovement();

        // Take photo on mouse click or first touch // Compatible with both mobile n keyboard
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            TakePhoto();
        }
    }

    void HandleMovement()
    {
        // Keyboard movement (WASD / Arrow Keys) THIS IS FOR PC MOVEMENT
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h, v, 0) * moveSpeed * Time.deltaTime);

        // Touch movement (dragging finger moves camera) THUS IS FOR MOBILE MOVEMENT
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 delta = touch.deltaPosition;
            transform.Translate(new Vector3(delta.x, delta.y, 0) * touchSensitivity);
        }
    }

    void TakePhoto()
    {
        // Convert screen center to world position
        Vector2 screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        // Detect Cheese Creatures using OverlapCircle for a small area // circle is expanded later on in the hierachy anyways
        Collider2D hit = Physics2D.OverlapCircle(screenCenter, captureRadius, cheeseCreatureLayer);

        if (hit != null)
        {
            Debug.Log("Cheese Creature captured: " + hit.name);
            score += scorePerCatch;

            // Play camera flash sound
            if (cameraAudioSource != null && cameraFlashSound != null)
                cameraAudioSource.PlayOneShot(cameraFlashSound);

            Destroy(hit.gameObject);

            if (scoreText != null)
                scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.Log("No Cheese Creatures in frame!"); //wahhhh good job debug log
        }

        // Trigger camera flash effect
        if (flashOverlay != null)
            StartCoroutine(FlashEffect());
    }

    IEnumerator FlashEffect() // THIS DOESNT EVEN FUCKING WORK
    {
        // Show flash
        flashOverlay.color = new Color(1, 1, 1, 0.8f);

        // Short delay
        yield return new WaitForSeconds(0.05f);

        // Fade out smoothly
        float fadeTime = 0.2f;
        float elapsed = 0f;
        Color startColor = flashOverlay.color;
        Color endColor = new Color(1, 1, 1, 0f);

        while (elapsed < fadeTime)
        {
            elapsed += Time.deltaTime;
            flashOverlay.color = Color.Lerp(startColor, endColor, elapsed / fadeTime);
            yield return null;
        }

        flashOverlay.color = endColor; // Ensure fully invisible
    }

    // Optional: Visualize detection area in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow; // cause cheese duh
        Vector2 screenCenter = Camera.main != null ? Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0)) : transform.position;
        Gizmos.DrawWireSphere(screenCenter, captureRadius);
    }
}

