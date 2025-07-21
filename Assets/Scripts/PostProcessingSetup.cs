using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingSetup : MonoBehaviour
{
    private Volume volume;
    private VolumeProfile volumeProfile;

    private Vignette vignetteEffect;

    void Start()
    {
        // Find the GameObject named "PostProcessing" in the scene
        GameObject postProcessingObject = GameObject.Find("PostProcessing");
        if (postProcessingObject == null)
        {
            Debug.LogError("PostProcessing GameObject not found in the scene.");
            return;
        }

        // Get or add the Volume component
        volume = postProcessingObject.GetComponent<Volume>();
        if (volume == null)
        {
            volume = postProcessingObject.AddComponent<Volume>();
            volume.isGlobal = true;
        }

        // Get or create a VolumeProfile
        volumeProfile = volume.profile;
        if (volumeProfile == null)
        {
            volumeProfile = ScriptableObject.CreateInstance<VolumeProfile>();
            volume.profile = volumeProfile;
        }

        // Configure Vignette effect (keep this for the teleporting effect)
        if (!volumeProfile.TryGet(out vignetteEffect))
        {
            vignetteEffect = volumeProfile.Add<Vignette>(true);
        }
        vignetteEffect.intensity.value = 0.3f;  // Mild vignette for subtle edge darkening
        vignetteEffect.smoothness.value = 0.7f; // Smooth transition for a softer vignette

        // Anti-aliasing is now handled by the URP
    }
}
