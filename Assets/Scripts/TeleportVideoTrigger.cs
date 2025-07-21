using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class TeleportVideoTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer;   // Reference to your VideoPlayer
    public float delay = 2f;          // Set the delay time in seconds for the first trigger
    public bool hasPlayed = false;    // Flag to check if the video has been played

    private void Start()
    {
        // Ensure the video player is hidden at the start
        if (videoPlayer != null)
        {
            videoPlayer.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone and the video hasn't been played
        if (other.CompareTag("Player") && !hasPlayed)
        {
            StartCoroutine(PlayTeleportVideoWithDelay());
            hasPlayed = true;  // Mark that the video has been played once
        }
    }

    // Coroutine to delay the video start only for the first time
    private IEnumerator PlayTeleportVideoWithDelay()
    {
        yield return new WaitForSeconds(delay);  // Wait for the delay
        PlayVideo();  // Play the video after delay
    }

    // Method to start playing the video (used for both delayed start and restart without delay)
    public void PlayVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.gameObject.SetActive(true);  // Show the video player
            videoPlayer.Play();                      // Start playing the video
        }
    }

    // Method to restart the video (without delay)
    public void RestartVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Stop();  // Stop the current video
            videoPlayer.Play();  // Restart the video
            videoPlayer.gameObject.SetActive(true);  // Ensure the player is visible
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player leaves the trigger zone
        if (other.CompareTag("Player"))
        {
            if (videoPlayer != null)
            {
                videoPlayer.Stop();  // Stop the video
                videoPlayer.gameObject.SetActive(false);  // Hide the video player
            }
        }
    }

    // This method is called when the video finishes
    private void OnVideoEnd(VideoPlayer vp)
    {
        // Stop and hide the video player when the video ends
        videoPlayer.Stop();
        if (videoPlayer != null)
        {
            videoPlayer.gameObject.SetActive(false);
        }
    }
}
