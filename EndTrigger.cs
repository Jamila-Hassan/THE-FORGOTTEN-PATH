using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour
{
    public GameObject levelCompleteUI; // Assign in Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER ENTERED! Showing level complete UI...");
            Time.timeScale = 0f; // Pause game
            levelCompleteUI.SetActive(true); // Show UI
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ContinueToLevelTwo()
    {
        Debug.Log("Loading LevelTwo...");
        Time.timeScale = 1f; // Resume game
        SceneManager.LoadScene("LevelTwo"); // Replace with your Level 2 scene name
    }

    public void QuitGame()
    {
        Debug.Log("Showing Game Over screen...");
        Time.timeScale = 1f; // Resume game
        SceneManager.LoadScene("GameOver Scene"); // Replace with your Game Over scene name
    }
}
