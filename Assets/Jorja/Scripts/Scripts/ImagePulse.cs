using UnityEngine;
using UnityEngine.UI; // Required for Image component
using System.Collections; // Required for Coroutines

public class ImagePulse : MonoBehaviour
{
    public RectTransform imageToPulse;
    public float pulseScale = 1.2f;   // How large the image grows
    public float pulseDuration = 0.2f; // Speed of the pulse

    public void Pulse()
    {
        StartCoroutine(PulseRoutine());
    }

    private IEnumerator PulseRoutine()
    {
        Vector3 originalScale = imageToPulse.localScale;
        Vector3 targetScale = originalScale * pulseScale;

        // Scale up
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / pulseDuration;
            imageToPulse.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null;
        }

        // Scale back down
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / pulseDuration;
            imageToPulse.localScale = Vector3.Lerp(targetScale, originalScale, t);
            yield return null;
        }

        imageToPulse.localScale = originalScale; // final reset
    }
}
