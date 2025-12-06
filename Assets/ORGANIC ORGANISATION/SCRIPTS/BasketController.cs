using System.Collections;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveDirection = 0f;

    [Header("Fruit Settings")]
    [SerializeField] public Transform[] fruitObject; // Assign in Inspector

    [Header("Static Gameplay Flags")]
    public static string spawnedYet = "no"; // Has the fruit spawned?
    public static Vector2 basketxPosition;
    public static Vector2 spawnPosition;
    public static string newfruit = "no";
    public static int whichFruit = 0;

    void Update()
    {
        // Update basket movement
        HandleMovement();

        // Update basket position for fruits to follow
        basketxPosition = transform.position;

        // Spawn new fruits
        SpawnFruit();
        ReplaceFruit();
    }

    void HandleMovement()
    {
        // Keyboard controls
        if (Input.GetKey("a"))
            moveDirection = -1f;
        else if (Input.GetKey("d"))
            moveDirection = 1f;
        else
            moveDirection = 0f;

        // Touch controls
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                if (touch.position.x < Screen.width / 2)
                    moveDirection = -1f;
                else
                    moveDirection = 1f;
            }
        }

        // Apply movement
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(moveDirection * moveSpeed, 0);
    }

    void SpawnFruit()
    {
        if (spawnedYet == "no")
        {
            StartCoroutine(SpawnTimer());
            spawnedYet = "yes";
        }
    }

    void ReplaceFruit()
    {
        if (newfruit == "yes")
        {
            newfruit = "no"; // reset flag
            Instantiate(fruitObject[whichFruit], spawnPosition, fruitObject[0].rotation);
        }
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(0.75f);
        Instantiate(fruitObject[Random.Range(0, fruitObject.Length)], transform.position, fruitObject[0].rotation);
    }
}
