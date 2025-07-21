using UnityEngine;

public class ButtonTriggerTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Button Trigger Entered by: " + other.gameObject.name);
    }
}
