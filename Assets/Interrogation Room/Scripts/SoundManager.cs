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
    public AudioSource audioSource;
    private AudioSource audioSource2;
    public UIcontroller uiController;

    public void Start()
    {
        //audioSource = gameObject.AddComponent<AudioSource>();
        StartCoroutine(startFirstVoiceline());
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
        if (currentVoicelineIndex == currentVoicelines.Length)
            {
            if(eventManager.noCount > 4)
            {
                PlayFailureVoiceline();
            }
            else if(eventManager.noCount < 4)
            {
                PlaySuccessVoiceline();
            }
            }
        Debug.Log("Next Voiceline Play");
        
    }
    public void PlaySuccessVoiceline()
    {
        audioSource.clip = finalSuccess[0];
        audioSource.Play();
    }
    public void PlayFailureVoiceline()
    {
        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource.clip = finalFaliure[0];
        audioSource.Play();
        audioSource2.clip = finalFaliure[1];
        audioSource2.PlayDelayed(14f);
        uiController.StartFadeBlackOutSquareCoroutine();
    }

    public IEnumerator startFirstVoiceline()
    {
        yield return new WaitForSeconds(6f);
        PlayNextVoiceline();
    }

   
}
