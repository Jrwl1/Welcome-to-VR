using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopDarts : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dart")
        {
            // Get the dart's Rigidbody
            Rigidbody dartRigidbody = other.gameObject.GetComponent<Rigidbody>();

            if (dartRigidbody != null)
            {
                // Stop the dart's motion by setting its velocity and angular velocity to zero
                dartRigidbody.velocity = Vector3.zero;
                dartRigidbody.angularVelocity = Vector3.zero;

                // Disable gravity to prevent the dart from falling off
                dartRigidbody.useGravity = false;

                // Freeze the dart's position and rotation to make it stick
                dartRigidbody.constraints = RigidbodyConstraints.FreezeAll;

                // Make the dart a child of the dartboard for stability (Optional)
                other.gameObject.transform.SetParent(transform);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
