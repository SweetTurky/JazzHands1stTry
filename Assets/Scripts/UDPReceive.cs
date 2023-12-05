using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPReceive : MonoBehaviour
{

    Thread receiveThread;
    UdpClient client; 
    public int port = 5052;
    public bool startRecieving = true;
    public bool printToConsole = false;
    public string data;
    public bool gooseBumps = false;


    public void Start()
    {

        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    public void Update()
    {
      
    }
    // receive thread
    private void ReceiveData()
    {

        client = new UdpClient(port);
        while (startRecieving)
        {

            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);
                data = Encoding.UTF8.GetString(dataByte);
                //Debug.Log(data);
                if (data.Trim() == "0 No")
                {
                    gooseBumps = false;
                }
                else if (data.Trim() == "1 Yes")
                {
                    gooseBumps = true;
                }

                if (printToConsole) { print(data); }
                
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
        
    }

}
