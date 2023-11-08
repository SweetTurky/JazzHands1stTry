using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int player1CupsDestroyed = 0;
    public int player2CupsDestroyed = 0;

    public AudioClip victorySound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckWinCondition(CupOwner owner)
    {
        if (owner == CupOwner.Player1)
        {
            player1CupsDestroyed++;
        }
        else if (owner == CupOwner.Player2)
        {
            player2CupsDestroyed++;
        }

        if (player1CupsDestroyed == 6)
        {
            PlayVictoryEffects();
            Debug.Log("Player 2 wins!");
            ResetGame();
        }
        else if (player2CupsDestroyed == 6)
        {
            PlayVictoryEffects();
            Debug.Log("Player 1 wins!");
            ResetGame();
        }
    }

    private void PlayVictoryEffects()
    {
        // Add code here to play victory sound and sparks
        // For example:
        // AudioSource.PlayClipAtPoint(victorySound, Camera.main.transform.position);
    }

    private void ResetGame()
    {
        player1CupsDestroyed = 0;
        player2CupsDestroyed = 0;
        // Add any additional reset logic here
    }
}
