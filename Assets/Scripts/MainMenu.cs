using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // List of environment scenes
    public string[] environmentScenes;

     public void Awake()
    {
        // Initialize the environmentScenes array with scene names
        environmentScenes = new string[]
        {
            "BarScene",
            "CloudScene",
            "UnderwaterScene"
        };
    }

    // Function to handle button clicks
    public void ChangeEnvironment(int index)
    {
        // Check if the index is within the array bounds
        if (index >= 0 && index < environmentScenes.Length)
        {
            // Load the selected environment scene
            SceneManager.LoadScene(environmentScenes[index]);
        }
        else
        {
            Debug.LogWarning("Invalid environment index!");
        }
    }
}

