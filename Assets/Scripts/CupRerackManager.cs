using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupRerackManager : MonoBehaviour
{
    public GameObject cupParent; // Parent object containing all cups
    private int remainingCups; // Initial cup count (should be 6 if 6-cup game bool is true or 10 if bool false)

    private bool rerackAvailable = true;

    private void Update()
    {
        // Check the cup count and enable rerack option based on the remaining cups
        if (remainingCups <= 4 && remainingCups > 0 && rerackAvailable)
        {
            if (remainingCups == 4)
            {
                // Allow rerack for 4 cups: Square, Diamond, Rhombus patterns
                // Show UI/Pop-up to choose pattern and rerack cups accordingly
                // Implement reracking logic based on the chosen pattern
                // Example: RerackCups(SquarePattern);
            }
            else if (remainingCups == 3)
            {
                // Allow rerack for 3 cups: Triangle, Line (Vertical), Line (Horizontal) patterns
                // Show UI/Pop-up to choose pattern and rerack cups accordingly
                // Example: RerackCups(TrianglePattern);
            }
            else if (remainingCups == 2)
            {
                // Allow rerack for 2 cups: "I" shape, Flat Line patterns
                // Show UI/Pop-up to choose pattern and rerack cups accordingly
                // Example: RerackCups(IShapePattern);
            }

            // Disable rerack option after reracking once
            rerackAvailable = false;
        }
    }

    // Example method for reracking cups based on a chosen pattern
    private void RerackCups(PatternType pattern)
    {
        // Logic to rerack cups based on the chosen pattern
        switch (pattern)
        {
            case PatternType.Square:
                // Implement Square pattern rerack
                break;
            case PatternType.Diamond:
                // Implement Diamond pattern rerack
                break;
            case PatternType.Rhombus: 
                break;
            case PatternType.LineVertical: 
                break;
                // Implement other patterns similarly
        }
    }

    // Method to decrement cup count when a cup is hit
    public void CupHit()
    {
        remainingCups--;
    }
}

public enum PatternType
{
    Square,
    Diamond,
    Rhombus,
    Triangle,
    LineVertical,
    LineHorizontal,
    IShape,
    FlatLine
}
