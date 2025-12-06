using UnityEngine;

public class SoundEffectsManagerSteakSplitter : MonoBehaviour
{
    AudioSource aud;

    public void Play()
    {
        aud = GetComponent<AudioSource>();
        aud.Play();
    }
}
