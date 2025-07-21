using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleport : MonoBehaviour
{
    public GameObject rightTeleport;

    public InputActionProperty rightActivate; // Reference to the InputAction for reading movement

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rightTeleport.SetActive(rightActivate.action.ReadValue<float>() > 0.1f);

        if (rightActivate != null && rightActivate.action != null && rightActivate.action.enabled)
        {
            Vector2 inputValue = rightActivate.action.ReadValue<Vector2>();
            rightTeleport.SetActive(inputValue.magnitude > 0.1f);
        }
    }
}
