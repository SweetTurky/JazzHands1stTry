using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.WitAi;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class ActivateVoice : MonoBehaviour
{
    public InputActionProperty voiceActivationButton;

     [SerializeField]
    private Wit wit;

    private void Update()
    {
        if (wit == null) wit = GetComponent<Wit>();
        if (voiceActivationButton.action.ReadValue<float>() > 0)
        {
            WitActivate();
            Debug.Log("Button pressed1");
        }

        // Debugging information
        float buttonValue = voiceActivationButton.action.ReadValue<float>();
        Debug.Log("Button Value: " + buttonValue);

        if (buttonValue > 0)
        {
            WitActivate();
            Debug.Log("Button pressed1");
        }
    }

    public void TriggerPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        WitActivate();
        Debug.Log("Button pressed");
    }
    public void WitActivate()
    {
        wit.Activate();
    }
}