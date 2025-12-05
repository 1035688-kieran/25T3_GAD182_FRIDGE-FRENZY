using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    AudioSource aud;

    public void Play()
    {
        aud = GetComponent<AudioSource>();
        aud.Play();
    }
}
