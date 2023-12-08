using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateVoiceNew : MonoBehaviour
{
    [SerializeField]
    public WitService wit;

    private void Update()
    {
        if (wit == null) wit = GetComponent<WitService>();

        // Check for spacebar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Call the function to start Wit.ai processing
            WitActivate();
        }
    }
    public void WitActivate()
    {
        wit.Activate();
    }
}
