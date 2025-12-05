using UnityEngine;

public class SoundEffectsManagerBreadButterer : MonoBehaviour
{
    AudioSource aud;

    public void Play()
    {
        aud = GetComponent<AudioSource>();
        aud.Play();
    }
}
