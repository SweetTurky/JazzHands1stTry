using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public BiometricInputManager biometricInputManager;
    public AudioClip[] voicelinesNeutral;
    public AudioClip[] voicelinesAngry;
    public AudioClip finalSuccess;
    public AudioClip finalFaliure;
    public int currentVoicelineIndex = 0;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        PlayNextVoiceline();
    }

    public void PlayNextVoiceline()
    {
        AudioClip[] currentVoicelines = biometricInputManager.isAngry ? voicelinesAngry : voicelinesNeutral;
        if (currentVoicelineIndex < currentVoicelines.Length)
        {
            audioSource.clip = currentVoicelines[currentVoicelineIndex];
            audioSource.Play();
            currentVoicelineIndex++;
        }
        else
        {
            // All voicelines played, handle accordingly (e.g., end of dialogue)
        }
    }
    public void PlaySuccessVoiceline()
    {
        
    }
    public void PlayFailureVoiceline()
    {
        
    }
}
