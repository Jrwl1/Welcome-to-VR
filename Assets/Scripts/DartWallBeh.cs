using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartWallBeh : MonoBehaviour
{
    // The dartboard handles collisions with the dart
    void OnTriggerEnter(Collider other)
    {
        // Check if a dart hit the dartboard
        if (other.CompareTag("Dart"))
        {
            // Additional logic could be added here if needed for scoring, etc.
        }
    }
}
