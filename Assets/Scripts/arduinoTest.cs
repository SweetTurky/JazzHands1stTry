using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;




public class arduinoTest : MonoBehaviour
{
    public float gsrValue;
    public float hrmValue;

    public string portName = "COM3"; //GSR
    public int baudRate = 9600;
    //public float measurementDuration = 5f;

    private SerialPort serialPort;
    //public List<float> gsrValues = new List<float>();
    //private float elapsedTime = 0f;


    public string portName2 = "COM14"; //HRM
    public int baudRate2 = 115200;
    //public float measurementDuration2 = 5f;

    private SerialPort serialPort2;
    //public List<float> hrmValues = new List<float>();
    //private float elapsedTime = 0f;

    /*public float graphWidth = 300f; // Width of the graph in pixels
    public float graphHeight = 200f; // Height of the graph in pixels
    public float updateFrequency = 0.1f; // Update frequency for plotting data
    
    public Image graphImage; // Reference to the UI Image representing the graph
    */

    public float GSRmeasurement1;
    public float GSRmeasurement2;

    public float HRMmeasurement1;
    public float HRMmeasurement2;

    // Start is called before the first frame update
    void Start()
    {
        serialPort = new SerialPort(portName, baudRate); //GSR
        serialPort2 = new SerialPort(portName2, baudRate2); //HRM
        OpenSerialPort();

    }

    // Update is called once per frame
    void Update()
    {
        
       

    }

    public void gsrRead()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string incomingData = serialPort.ReadLine();
                //Debug.Log("Received data(GSR): " + incomingData);

                gsrValue = float.Parse(incomingData); // Assuming incoming data is a float value
                /*gsrValues.Add(gsrValue);

                elapsedTime += Time.deltaTime;

                if (elapsedTime >= measurementDuration)
                {
                    //PlotGSRData();
                    CalculateMeanGSRValue();
                    elapsedTime = 0f;
                }*/
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("Error reading serial port: " + e.Message);
            }
        }
    }

    public void hrmRead()
    {
        if (serialPort2.IsOpen)
        {
            try
            {
                string incomingData2 = serialPort2.ReadLine();
                //Debug.Log("Received data(HRM): " + incomingData2);

                hrmValue = float.Parse(incomingData2); // Assuming incoming data is a float value
                //hrmValues.Add(hrmValue);

                //elapsedTime += Time.deltaTime;

                /*if (elapsedTime >= measurementDuration)
                {
                    //PlotGSRData();
                    CalculateMeanGSRValue();
                    elapsedTime = 0f;
                }*/
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("Error reading serial port: " + e.Message);
            }
        }
    }



    public void OpenSerialPort()
    {
        try
        {
            serialPort.Open();
            serialPort2.Open();
            Debug.Log("Serial port opened: " + portName + portName2);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("Error opening serial port: " + e.Message);
        }
    }

    void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
            serialPort2.Close();
            Debug.Log("Serial port closed");
        }
    }

    /*void CalculateMeanGSRValue()
    {
        if (gsrValues.Count > 0)
        {
            float sum = 0f;
            foreach (float value in gsrValues)
            {
                sum += value;
            }
            float meanGSRValue = sum / gsrValues.Count;

            Debug.Log("Mean GSR value over " + measurementDuration + " seconds: " + meanGSRValue);

            // Reset the list for the next calculation
            gsrValues.Clear();
        }
    }*/

    /*void PlotGSRData()
    {
        if (gsrValues.Count > 0)
        {
            float graphStep = graphWidth / gsrValues.Count;
            Texture2D tex = new Texture2D((int)graphWidth, (int)graphHeight);
            Color[] colors = new Color[(int)graphWidth * (int)graphHeight];

            for (int i = 0; i < gsrValues.Count; i++)
            {
                int y = Mathf.RoundToInt(Mathf.Lerp(0, graphHeight, Mathf.InverseLerp(0f, 1023f, gsrValues[i])));
                for (int j = 0; j < graphStep; j++)
                {
                    int index = Mathf.RoundToInt((i * graphStep) + j);
                    for (int k = 0; k < y; k++)
                    {
                        colors[index + (k * (int)graphWidth)] = Color.green; // Change color as needed
                    }
                }
            }

            tex.SetPixels(colors);
            tex.Apply();

            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, graphWidth, graphHeight), Vector2.zero);
            graphImage.sprite = sprite;

            gsrValues.Clear();
        }
    }*/

}
