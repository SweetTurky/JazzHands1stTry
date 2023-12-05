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
            soundManager.PlayNextVoiceline();

            if (noCount > 4)
            {
                LoseGame();
            }
            else if (noCount < 4)
            {
                WinGame();
            }
        }
        else if(Input.GetKeyDown(KeyCode.N))
        {
            noCount++;
            soundManager.PlayNextVoiceline();

            if (noCount > 4)
            {
                LoseGame();
            }
            else if (noCount < 4)
            {
                
                
                WinGame();
                
            }
        }
    }

    private void WinGame()
    {
        soundManager.PlaySuccessVoiceline();
    }
    private void LoseGame()
    {
        soundManager.PlayFailureVoiceline();
    }
}
