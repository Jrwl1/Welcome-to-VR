using UnityEngine;

public class ScoreEffect : MonoBehaviour
{
    public GameObject fireworkPrefab;  // The firework prefab
    public Transform fireworkSpawnPosition;  // The position where fireworks will spawn
    public AudioSource scoreSound;  // Optional: sound effect

    private void OnTriggerEnter(Collider other)
    {
        // Log when something enters the trigger
        Debug.Log("Trigger entered by: " + other.gameObject.name);

        // Check if the object entering the trigger is the basketball
        if (other.CompareTag("Basketball"))
        {
            Debug.Log("Basketball entered the hoop!");

            // Spawn the fireworks when the ball enters the hoop trigger zone
            if (fireworkPrefab != null)
            {
                // Ensure fireworks are rotated upwards
                Instantiate(fireworkPrefab, fireworkSpawnPosition.position, Quaternion.Euler(-90, 0, 0));
                Debug.Log("Fireworks triggered at: " + fireworkSpawnPosition.position);
            }
            else
            {
                Debug.LogWarning("Firework prefab is not assigned!");
            }

            // Play a sound if there's an audio source assigned
            if (scoreSound != null)
            {
                scoreSound.Play();
                Debug.Log("Score sound played.");
            }
            else
            {
                Debug.LogWarning("Score sound is not assigned!");
            }
        }
    }
}
