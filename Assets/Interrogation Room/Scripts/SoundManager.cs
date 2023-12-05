using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public BiometricInputManager biometricInputManager;
    public EventManager eventManager; 
    public AudioClip[] voicelinesNeutral;
    public AudioClip[] voicelinesAngry;
    public AudioClip[] finalSuccess;
    public AudioClip[] finalFaliure;
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
            //currentVoicelineIndex++;
        }
        else if(currentVoicelines.Length == 9 && eventManager.noCount > 4)
        {
            PlayFailureVoiceline();
        }
        else if(currentVoicelines.Length == 9 && eventManager.noCount < 4)
        {
            PlaySuccessVoiceline();
        }
    }
    public void PlaySuccessVoiceline()
    {
        audioSource.clip = finalSuccess[0];
        audioSource.Play();
    }
    public void PlayFailureVoiceline()
    {
        audioSource.clip = finalFaliure[0];
        audioSource.Play();
    }
}
