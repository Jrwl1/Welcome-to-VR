using UnityEngine;
using UnityEngine.Video;

public class VideoManagerJoystickTutorial : MonoBehaviour
{
    public VideoPlayer videoPlayer;       // Reference to the VideoPlayer
    public Renderer videoScreenRenderer;  // The screen where the video will play
    public GameObject button;             // The button to start the video
    public TMPro.TextMeshPro buttonText;  // The 3D TextMeshPro object for the text

    private bool hasVideoEnded = true;

    private void Start()
    {
        // Hide the screen but show the button and text at the start
        videoScreenRenderer.enabled = false;
        button.SetActive(true);
        buttonText.gameObject.SetActive(true);

        // Subscribe to the video ending event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        videoScreenRenderer.enabled = false;
        button.SetActive(true);
        buttonText.gameObject.SetActive(true);
        hasVideoEnded = true;
    }

    public void StartVideo()
    {
        if (hasVideoEnded)
        {
            // Hide the button and text, and show the screen to play the video
            button.SetActive(false);
            buttonText.gameObject.SetActive(false);
            videoScreenRenderer.enabled = true;

            // Start playing the video
            videoPlayer.Play();
            hasVideoEnded = false;
        }
    }

    private void OnDisable()
    {
        videoPlayer.loopPointReached -= OnVideoEnd;
    }
}
