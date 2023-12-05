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
        bool isAngry = biometricInputManager.IsAngry();
        // Check for player input (e.g., any key press)
        if (Input.GetKeyDown(KeyCode.Y)) // Change to the desired input
        {
            // Player input detected, play the next voiceline
            soundManager.PlayNextVoiceline(isAngry);

            if (noCount > 4 && soundManager.currentVoicelineIndex = 9)
            {
                LoseGame();
            }
            else if (noCount < 4 && soundManager.currentVoicelineIndex = 9)
            {
                WinGame();
            }
        }
        else if(Input.GetKeyDown(KeyCode.N))
        {
            noCount++;
            soundManager.PlayNextVoiceline(isAngry);

            if (noCount > 4 && soundManager.currentVoicelineIndex = 9)
            {
                LoseGame();
            }
            else if (noCount < 4 && soundManager.currentVoicelineIndex = 9)
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
