using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetButtonBehaviour : MonoBehaviour
{
    public Transform respawnPointPlayer1; // Assign in Inspector
    public Transform respawnPointPlayer2; // Assign in Inspector

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        //grabInteractable.selectEntered.AddListener(OnButtonPress);
    }

    /*private void OnButtonPress(XRBaseInteractor interactor)
    {
        PongballBehaviour ballBehaviour = interactor.GetComponentInChildren<PongballBehaviour>();

        if (ballBehaviour != null)
        {
            Transform parentObject = grabInteractable.transform.parent;
            if (parentObject != null)
            {
                if (parentObject.name == "Player1Cups")
                {
                    ballBehaviour.TeleportSphereTo(respawnPointPlayer1);
                }
                else if (parentObject.name == "Player2Cups")
                {
                    ballBehaviour.TeleportSphereTo(respawnPointPlayer2);
                }
            }
        }
    }*/
}
