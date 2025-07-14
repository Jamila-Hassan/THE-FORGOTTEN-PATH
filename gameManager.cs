using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverPanel; // Assign in Inspector

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void TriggerGameOver()
    {
        Debug.Log("Game Over triggered");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogWarning("No Game Over panel assigned.");
        }
    }
}
