using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // This function plays a given clip and destroys the GameObject afterwards.
    public void PlayAndDestroy(AudioClip clip)
    {
        if (clip == null)
        {
            Destroy(gameObject); // Don't crash if clip is null
            return;
        }

        AudioSource source = GetComponent<AudioSource>();
        source.clip = clip;
        source.spatialBlend = 0; // Ensures it's a 2D sound
        source.Play();

        // Destroy the GameObject after the clip finishes playing
        Destroy(gameObject, clip.length);
    }
}