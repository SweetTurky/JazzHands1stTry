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
    public arduinoTest arduinoTest;
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
        arduinoTest.GSRmeasurement1 = arduinoTest.gsrValue;
        yield return new WaitForSeconds(3f);
        lieCounter = 0;
        arduinoTest.GSRmeasurement2 = arduinoTest.gsrValue;


        if (uDPReceive.gooseBumps == true)
        {
            lieCounter++;
            Debug.Log("Goose Lie Counter+");
        }
        /*if (heartRateMonitorScript.heartRateHigh == true)
        {
            lieCounter++;
        }*/
        if (arduinoTest.GSRmeasurement2 - arduinoTest.GSRmeasurement1 >= 20)
        {
            lieCounter++;
            Debug.Log("GSR Lie Counter+");
        }
        if (lieCounter >= 2)
        {
            isAngry = true;
        }
        eventManager.VoiceInput();
    }
}
