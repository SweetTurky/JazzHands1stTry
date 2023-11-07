using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PongballBehaviour : MonoBehaviour
{
    public Transform respawnPoint; // Set this in the Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("triggerTag")) // Assuming you've set the tag of the trigger collider to "triggerTag"
        {
            TeleportSphere(); // Teleport the sphere
        }
    }

    void TeleportSphere()
    {
        transform.position = respawnPoint.position; // Set the position of the sphere to the respawn point
        GetComponent<Rigidbody>().velocity = Vector3.zero; // Reset any velocity

        if (TryGetComponent<XRGrabInteractable>(out var grabInteractable))
        {
            grabInteractable.enabled = true; // Enable the XR Grab Interactable script
        }

        if (TryGetComponent<XRBaseInteractable>(out var baseInteractable))
        {
            baseInteractable.enabled = true; // Enable the XR General Grab Interactable script
        }
    }
}
