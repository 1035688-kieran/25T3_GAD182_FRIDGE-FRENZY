using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    [SerializeField] SplitButton button;


    // This method is called when another collider enters this object's trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering object has a specific tag
        if (other.gameObject.CompareTag("Player")) // Replace "Player" with the tag of the object you're looking for
        {
            // Destroy this GameObject (the one the script is attached to)
            Destroy(other.gameObject);

            button.GetComponent<SplitButton>().ActivateButton();
        }
    }
}
