using UnityEngine;

public class JoystickTutorialRestartButton : MonoBehaviour
{
    public VideoManagerJoystickTutorial videoManager;  // Reference to the VideoManager script
    public string handTag = "Hands";                   // Tag for the player's hand or controller

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(handTag))
        {
            videoManager.StartVideo();
        }
    }
}
