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
        lieCounter = 0;
        arduinoTest.GSRmeasurement1 = arduinoTest.gsrValue;
        arduinoTest.HRMmeasurement1 = arduinoTest.hrmValue;
        yield return new WaitForSeconds(3f);
        arduinoTest.GSRmeasurement2 = arduinoTest.gsrValue;
        arduinoTest.HRMmeasurement2 = arduinoTest.hrmValue;

        if (uDPReceive.gooseBumps == true)
        {
            lieCounter++;
            Debug.Log("Goose Lie Counter+");
        }
        if (arduinoTest.HRMmeasurement2 - arduinoTest.HRMmeasurement1 >= 5)
        {
            lieCounter++;
        }
        if (arduinoTest.GSRmeasurement2 - arduinoTest.GSRmeasurement1 >= 10)
        {
            lieCounter++;
            Debug.Log("GSR Lie Counter+");
        }
        if (lieCounter >= 2)
        {
            isAngry = true;
            eventManager.noCount++;
        }
        else if (lieCounter < 2)
        {
            isAngry = false;
        }
       
        eventManager.VoiceInput();
    }
}
