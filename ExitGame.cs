using UnityEngine;

public class ExitToGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f; // Optional: pause the game
            Debug.Log("Game Over shown!");
        }
    }
}
