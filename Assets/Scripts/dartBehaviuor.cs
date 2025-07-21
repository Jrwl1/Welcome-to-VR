using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dartBehaviour : MonoBehaviour
{
    private bool hasHitDartboard = false;

    void Update()
    {
        // Once the dart has hit the board, stop updating
        if (hasHitDartboard) return;

        // Align dart's forward direction with its velocity for realistic motion
        if (GetComponent<Rigidbody>().useGravity)
        {
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            if (velocity != Vector3.zero)
            {
                // Rotate the dart to face in the direction of its velocity
                transform.rotation = Quaternion.LookRotation(velocity);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the dart hits the DartBoard
        if (other.CompareTag("DartBoard") && !hasHitDartboard)
        {
            hasHitDartboard = true;

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;  // Stop the dart's motion
            rb.angularVelocity = Vector3.zero;  // Stop rotation
            rb.useGravity = false;  // Disable gravity after it hits the dartboard
            rb.isKinematic = true;  // Set isKinematic to prevent further motion

            // Stick the dart to the exact point of impact
            Vector3 hitPoint = other.ClosestPoint(transform.position);
            transform.position = hitPoint;

            // Rotate the dart so that it sticks naturally into the dartboard
            transform.rotation = Quaternion.LookRotation(other.transform.forward);

            // Make the dart a child of the dartboard so it moves with it
            transform.SetParent(other.transform);
        }
    }
}
