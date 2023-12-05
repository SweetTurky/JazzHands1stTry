using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public SoundManager soundManager;
    public BiometricInputManager biometricInputManager;
    public int noCount = 0;
    private void Update()
    {
        
        // Check for player input (e.g., any key press)
        if (Input.GetKeyDown(KeyCode.Y)) // Change to the desired input
        {
            // Player input detected, play the next voiceline
            biometricInputManager.LieDetection();
        }
        else if(Input.GetKeyDown(KeyCode.N))
        {
            biometricInputManager.LieDetection();
            noCount++;
        }
    }

    public void VoiceInput()
    {
        soundManager.PlayNextVoiceline();
        soundManager.currentVoicelineIndex++;
        
    }
    
    public void WinGame()
    {
        soundManager.PlaySuccessVoiceline();
    }
    public void LoseGame()
    {
        soundManager.PlayFailureVoiceline();
    }
}
