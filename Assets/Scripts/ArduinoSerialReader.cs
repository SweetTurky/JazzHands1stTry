using UnityEngine;
using System;
using System.IO.Ports;

public class ArduinoSerialReader : MonoBehaviour
{
    SerialPort serialPort;
    string portName = "COM3"; // Change this to your Arduino's port
    int heartRate;

    void Start()
    {
        // Initialize the serial port
        serialPort = new SerialPort(portName, 9600);
        serialPort.ReadTimeout = 1000;

        try
        {
            // Open the serial port
            serialPort.Open();
            Debug.Log("Serial port opened");
        }
        catch (Exception e)
        {
            Debug.LogError("Error opening serial port: " + e.Message);
        }
    }

    void Update()
    {
        try
        {
            // Read data from the serial port
            string serialData = serialPort.ReadLine();
            heartRate = int.Parse(serialData); // Assuming the data received is an integer representing heart rate
            Debug.Log("Heart Rate: " + heartRate);
        }
        catch (TimeoutException) { }
        catch (Exception e)
        {
            Debug.LogError("Error reading from serial port: " + e.Message);
        }
    }

    public int GetHeartRate()
    {
        return heartRate;
    }

    void OnDestroy()
    {
        // Close the serial port when the script is destroyed or the application quits
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
            Debug.Log("Serial port closed");
        }
    }
}
