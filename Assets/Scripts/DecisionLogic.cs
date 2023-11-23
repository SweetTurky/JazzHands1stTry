using UnityEngine;
using System;
using System.IO.Ports;
using UnityEngine.Events;

public class DecisionLogic : MonoBehaviour
{
    // Reference to Speech Recognition script
    public SpeechRecognition speechRecognition;

    // Reference to Heart Rate Monitoring script
    public ArduinoSerialReader heartRateMonitor;

    int threshold = 80; // Set your heart rate threshold value here

    // Unity Events for truth and lie
    public UnityEvent OnTruth;
    public UnityEvent OnLie;

    void Update()
    {
        // Check if a response has been received from speech recognition
        if (speechRecognition != null && speechRecognition.IsResponseReceived)
        {
            string playerResponse = speechRecognition.GetPlayerResponse();
            Debug.Log("Player's response: " + playerResponse);

            // Check the player's response and heart rate against the threshold
            if (playerResponse.ToLower() == "yes")
            {
                CheckHeartRateForAnswer(true);
            }
            else if (playerResponse.ToLower() == "no")
            {
                CheckHeartRateForAnswer(false);
            }
        }
    }

    void CheckHeartRateForAnswer(bool isTruth)
    {
        if (heartRateMonitor != null)
        {
            int heartRate = heartRateMonitor.GetHeartRate(); // Get the current heart rate
            Debug.Log("Heart Rate: " + heartRate);

            // Determine if it's a lie or truth based on heart rate and player's response
            if ((isTruth && heartRate <= threshold) || (!isTruth && heartRate > threshold))
            {
                if (isTruth)
                {
                    OnTruth.Invoke(); // Invoke the event for truth
                }
                else
                {
                    OnLie.Invoke(); // Invoke the event for lie
                }
            }
            // Handle cases where the heart rate and response do not align
            else
            {
                Debug.Log("Inconclusive");
                // Handle inconclusive response (heart rate and response don't align)
            }
        }
    }
}
