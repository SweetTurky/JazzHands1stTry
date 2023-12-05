using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiometricInputManager : MonoBehaviour
{
    public bool isAngry = false;
    public int lieCounter;
    public UDPReceive uDPReceive;
    public SoundManager soundManager;
    public EventManager eventManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LieDetection()
    {
        StartCoroutine(LieDetector());
    }
    public IEnumerator LieDetector()
    {
        yield return new WaitForSeconds(3f);
        lieCounter = 0;
        
        if (uDPReceive.gooseBumps == true)
        {
            lieCounter++;
        }
        /*if (heartRateMonitorScript.heartRateHigh == true)
        {
            lieCounter++;
        }
        if (galvanicSkinResponseScript.moistureHigh == true)
        {
            lieCounter++;
        }*/
        if (lieCounter >= 2)
        {
            isAngry = true;
        }
        eventManager.VoiceInput();
    }
}
