using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public Transform respawnPoint; // Set this in the Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ControllerCollider")) // Assuming you've set the tag of the controller collider to "ControllerCollider"
        {
            Debug.Log("Button Triggered!"); // Add this line to log a message when the button is triggered
            TeleportSphere(); // Teleport the sphere
        }
    }

    void TeleportSphere()
    {
        GameObject ball = GameObject.FindWithTag("PongBall"); // Assuming your ball has a tag "PongBall"

        if (ball != null)
        {
            ball.transform.position = respawnPoint.position; // Teleport the ball
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero; // Reset any velocity
        }
    }
}
