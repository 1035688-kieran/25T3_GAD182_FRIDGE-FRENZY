using UnityEngine;
using UnityEngine.UI;

public class ButtonAudioSource : MonoBehaviour
{
    public AudioSource buttonAudioSource; // Assign this in the Inspector

    void Start()
    {
        // Get a reference to the Button component on this GameObject
        Button button = GetComponent<Button>();

        // Add a listener to the button's onClick event
        if (button != null)
        {
            button.onClick.AddListener(PlayButtonSound);
        }
    }

    // This function will be called when the button is clicked
    public void PlayButtonSound()
    {
        if (buttonAudioSource != null)
        {
            buttonAudioSource.Play();
        }
    }
}
