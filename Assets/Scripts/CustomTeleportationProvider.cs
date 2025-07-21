using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UnityEngine.XR.Interaction.Toolkit
{
    [AddComponentMenu("XR/Locomotion/Custom Teleportation Provider", 11)] // Renaming it to Custom Teleportation Provider
    public class CustomTeleportationProvider : TeleportationProvider // Custom class inherits from TeleportationProvider
    {
        [SerializeField]
        [Tooltip("The Image for the tunneling vignette effect.")]
        private Image vignetteImage; // Reference to the black vignette image for the tunneling effect

        [SerializeField]
        [Tooltip("The duration (in seconds) for the tunneling vignette effect.")]
        private float vignetteDuration = 0.5f;

        // Renamed these fields to avoid conflicts with the base class
        private bool customHasExclusiveLocomotion = false;
        private float customTimeStarted = -1f;

        protected override void Awake()
        {
            base.Awake();
            if (system != null && delayTime > 0f && delayTime > system.timeout)
                Debug.LogWarning($"Delay Time ({delayTime}) is longer than the Locomotion System's Timeout ({system.timeout}).", this);
        }

        protected override void Update()
        {
            if (!validRequest)
            {
                locomotionPhase = LocomotionPhase.Idle;
                return;
            }

            if (!customHasExclusiveLocomotion) // Use renamed field
            {
                if (!BeginLocomotion())
                    return;

                customHasExclusiveLocomotion = true; // Set exclusive locomotion flag
                locomotionPhase = LocomotionPhase.Started;
                customTimeStarted = Time.time; // Record time

                // Start the tunneling vignette effect
                StartCoroutine(TunnelingEffect(1));
            }

            // Wait for configured Delay Time
            if (delayTime > 0f && Time.time - customTimeStarted < delayTime) // Use renamed field
                return;

            locomotionPhase = LocomotionPhase.Moving;

            var xrOrigin = system.xrOrigin;
            if (xrOrigin != null)
            {
                var heightAdjustment = xrOrigin.Origin.transform.up * xrOrigin.CameraInOriginSpaceHeight;
                var cameraDestination = currentRequest.destinationPosition + heightAdjustment;

                xrOrigin.MoveCameraToWorldLocation(cameraDestination);
            }

            EndLocomotion();
            customHasExclusiveLocomotion = false; // Reset exclusive locomotion flag
            validRequest = false;
            locomotionPhase = LocomotionPhase.Done;

            // End the tunneling vignette effect
            StartCoroutine(TunnelingEffect(0));
        }

        private IEnumerator TunnelingEffect(float targetAlpha)
        {
            Color vignetteColor = vignetteImage.color;
            float startAlpha = vignetteImage.color.a;
            float elapsedTime = 0f;

            while (elapsedTime < vignetteDuration)
            {
                elapsedTime += Time.deltaTime;
                float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / vignetteDuration);
                vignetteColor.a = newAlpha;
                vignetteImage.color = vignetteColor;
                yield return null;
            }

            // Ensure final alpha is set correctly
            vignetteColor.a = targetAlpha;
            vignetteImage.color = vignetteColor;
        }
    }
}
