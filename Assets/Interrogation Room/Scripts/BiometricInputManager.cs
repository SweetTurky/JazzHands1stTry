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
        Debug.Log("LieDetector start");
    }
    public IEnumerator LieDetector()
    {
        lieCounter = 0;
        arduinoTest.OpenSerialPort();
        arduinoTest.gsrRead();
        arduinoTest.hrmRead();
        arduinoTest.GSRmeasurement1 = arduinoTest.gsrValue;
        arduinoTest.HRMmeasurement1 = arduinoTest.hrmValue;
        Debug.Log("GSR= " + arduinoTest.GSRmeasurement1 + "HRM= " + arduinoTest.HRMmeasurement1);
        yield return new WaitForSeconds(4f);
        arduinoTest.gsrRead();
        arduinoTest.hrmRead();
        arduinoTest.GSRmeasurement2 = arduinoTest.gsrValue;
        arduinoTest.HRMmeasurement2 = arduinoTest.hrmValue;
        Debug.Log("GSR2= " + arduinoTest.GSRmeasurement2 + "HRM2= " + arduinoTest.HRMmeasurement2);

        if (uDPReceive.gooseBumps == true)
        {
            lieCounter++;
            Debug.Log("Goose Lie Counter+");
        }
        if (arduinoTest.HRMmeasurement2 > arduinoTest.HRMmeasurement1)
        {
            lieCounter++;
            Debug.Log("Hear Rate Lie Counter+");
        }
        if (arduinoTest.GSRmeasurement2 > arduinoTest.GSRmeasurement1)
        {
            lieCounter++;
            Debug.Log("GSR Lie Counter+");
        }
        if (lieCounter >= 1)
        {
            isAngry = true;
            eventManager.noCount++;
        }
        else if (lieCounter < 1)
        {
            isAngry = false;
        }
        arduinoTest.CloseSerialPort();
        eventManager.VoiceInput();
    }
}
