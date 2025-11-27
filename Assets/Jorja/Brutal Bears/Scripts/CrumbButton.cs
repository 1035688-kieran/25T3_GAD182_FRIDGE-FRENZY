using UnityEngine;

public class CrumbButton : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public void PlayParticles()
    {
        if (particleSystem != null)
            particleSystem.Play();
    }
}
