using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] voicelinesNeutral;
    public AudioClip[] voicelinesAngry;
    public AudioClip[] finalSuccess;
    public AudioClip[] finalFaliure;
    public int currentVoicelineIndex = 0;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        PlayNextVoiceline();
    }

    public void PlayNextVoiceline(bool isAngry)
    {
        AudioClip[] currentVoicelines = isAngry ? voicelinesAngry : voicelinesNeutral;
        if (currentVoicelineIndex < currentVoicelines.Length)
        {
            audioSource.clip = voicelines[currentVoicelineIndex];
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
        audioSource.clip = voicelinesNeutral[finalSuccess];
    }
    public void PlayFailureVoiceline()
    {
        audioSource.clip = voicelinesNeutral[finalFaliure];
    }
}
