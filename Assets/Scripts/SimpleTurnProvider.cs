using UnityEngine;

public class SimpleTurnProvider : MonoBehaviour
{
    public float turnSpeed = 60f; // Speed of the turn
    public float smoothingFactor = 0.1f; // Smoothing factor

    private float turnInput;
    private float smoothTurnVelocity;

    void Update()
    {
        // Read input from the left joystick (X axis for turning)
        turnInput = Input.GetAxis("Horizontal"); // Using the standard Input system

        // Calculate the target rotation
        float targetTurn = turnInput * turnSpeed * Time.deltaTime;

        // Interpolate the rotation
        float smoothedTurn = Mathf.SmoothDampAngle(transform.eulerAngles.y, transform.eulerAngles.y + targetTurn, ref smoothTurnVelocity, smoothingFactor);

        // Apply the smoothed turn to the XR Rig 
        transform.rotation = Quaternion.Euler(0, smoothedTurn, 0);
    }
}
