using UnityEngine;
using UnityEngine.Events;

public class SpeechRecognition : MonoBehaviour
{
    // Example variables for speech recognition service/library
    // Replace these with variables/methods based on your chosen service/library
    private bool isResponseReceived = false;
    private string playerResponse = "";

    // Unity Event to signal when a response is received
    public UnityEvent OnResponseReceived;

    void Update()
    {
        // Example: Check for response from the speech recognition service
        if (Input.GetKeyDown(KeyCode.Y)) // Replace this with actual recognition logic
        {
            isResponseReceived = true;
            playerResponse = "yes";
            Debug.Log("Player responded: Yes");
            OnResponseReceived.Invoke(); // Invoke the event for response received
        }
        else if (Input.GetKeyDown(KeyCode.N)) // Replace this with actual recognition logic
        {
            isResponseReceived = true;
            playerResponse = "no";
            Debug.Log("Player responded: No");
            OnResponseReceived.Invoke(); // Invoke the event for response received
        }
    }

    public bool IsResponseReceived
    {
        get { return isResponseReceived; }
    }

    public string GetPlayerResponse()
    {
        isResponseReceived = false;
        return playerResponse;
    }
}
