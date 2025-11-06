using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    public Button myButton; // Assign your Button component here in the Inspector

    void Start()
    {
        // Optional: If you want to ensure the button is interactable at start
        if (myButton != null)
        {
            myButton.interactable = true;
        }
    }

    public void OnButtonPressedOnce()
    {
        if (myButton != null)
        {
            // Perform your desired action here
            Debug.Log("Button pressed! This will only happen once.");

            // Disable the button to prevent further presses
            myButton.interactable = false;
        }
    }
}
