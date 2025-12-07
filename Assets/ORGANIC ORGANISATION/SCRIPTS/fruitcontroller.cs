using UnityEngine;

public class fruitcontroller : MonoBehaviour
{
    [SerializeField] private string intheCloud = "yes";
    private bool hasMerged = false; // prevent double merging
    public AudioSource fruitAudioSource;
    public AudioClip dropClip;
    public AudioClip mergeClip;
    public GameObject AudioPlayerPrefab;

    private void Start()
    {

        fruitAudioSource = GetComponent<AudioSource>();

        if (transform.position.y < 3.5f)
            intheCloud = "no";
    }

    private void Update()
    {
        if (intheCloud == "yes")
            transform.position = BasketController.basketxPosition;

        if (Input.GetKeyDown("space"))
        {
            DropFromCloud();
            BasketController.spawnedYet = "no";
        }
    }

    private void DropFromCloud()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
        intheCloud = "no";

        if (fruitAudioSource != null && dropClip != null)
        {
            fruitAudioSource.PlayOneShot(dropClip);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only merge with same-tag fruit and if neither has merged yet
        if (!hasMerged && collision.gameObject.CompareTag(gameObject.tag))
        {
            fruitcontroller otherFruit = collision.gameObject.GetComponent<fruitcontroller>();

            if (otherFruit != null && !otherFruit.hasMerged)
            {
                hasMerged = true;
                otherFruit.hasMerged = true;

                // Spawn new fruit at midpoint
                Vector2 spawnPos = (transform.position + collision.transform.position) / 2f;
                BasketController.spawnPosition = spawnPos;
                BasketController.newfruit = "yes";

                // Get next fruit index (use BasketController instance)
                BasketController basket = FindObjectOfType<BasketController>();
                int currentFruitIndex = int.Parse(gameObject.tag);
                BasketController.whichFruit = Mathf.Min(currentFruitIndex + 1, basket.fruitObject.Length - 1);

                if (AudioPlayerPrefab != null && mergeClip != null)
                {
                    GameObject audioGO = Instantiate(AudioPlayerPrefab, BasketController.spawnPosition, Quaternion.identity);
                    audioGO.GetComponent<AudioPlayer>().PlayAndDestroy(mergeClip);
                }


                // Destroy both old fruits
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
