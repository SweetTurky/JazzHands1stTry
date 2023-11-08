using UnityEngine;

public enum CupOwner
{
    Player1,
    Player2
}

public class CupBehaviour : MonoBehaviour
{
    public CupOwner owner;
    public Transform respawnPoint; // Set this in the Inspector for each cup

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PongBall")) // Assuming you've set the tag of the ball to "Pongball"
        {
            PongballBehaviour ballBehaviour = other.GetComponent<PongballBehaviour>();
            if (ballBehaviour != null)
            {
                ballBehaviour.TeleportSphereTo(respawnPoint); // Teleport the ball to this cup's respawn point
            }
        }
    }
}
