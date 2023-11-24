using UnityEngine;
using System.Collections.Generic;

public class CupArrangement : MonoBehaviour
{
    public GameObject cupPrefab; // The cup prefab to instantiate
    public Transform startPoint; // The starting point for the triangle arrangement
    public float cupSpacing = 1.0f; // Spacing between cups

    public bool isSixCupGame = true; // Toggle between 6-cup and 10-cup game

    void Start()
    {
        if (isSixCupGame)
        {
            CreateTriangleArrangement(6);
        }
        else
        {
            CreateTriangleArrangement(10);
        }
    }

    void CreateTriangleArrangement(int totalCups)
    {
        List<GameObject> cups = new List<GameObject>();

        int rows = Mathf.CeilToInt(Mathf.Sqrt(totalCups * 2)); // Calculate rows based on total cups
        int cupsInRow = 1;
        int createdCups = 0;

        for (int row = 0; row < rows; row++)
        {
            float offsetX = -row * cupSpacing * 0.5f;
            for (int cupIndex = 0; cupIndex < cupsInRow; cupIndex++)
            {
                Vector3 cupPosition = startPoint.position + new Vector3(offsetX + cupIndex * cupSpacing, 0f, row * cupSpacing * Mathf.Sqrt(3) * 0.5f);
                GameObject newCup = Instantiate(cupPrefab, cupPosition, Quaternion.identity);
                cups.Add(newCup);

                createdCups++;
                if (createdCups >= totalCups)
                {
                    break; // Exit loop if all cups are created
                }
            }
            cupsInRow++;
            if (createdCups >= totalCups)
            {
                break; // Exit loop if all cups are created
            }
        }
    }
}
