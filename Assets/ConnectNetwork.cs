using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class ConnectNetwork : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        Debug.Log("Host is starting...");
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        Debug.Log("Client is starting...");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
