using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadEndTrigger: MonoBehaviour
{
    public GameObject miniGameUI; // Assign MiniGamePromptCanvas in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            miniGameUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Cursor unlocked & made visible");
        }
    }

    public void OnClickYes()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        SceneManager.LoadScene("DataStructure"); // Mini-game scene
    }

    public void OnClickNo()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        miniGameUI.SetActive(false); // Hides the UI
        GameManager.Instance.TriggerGameOver(); // Show Game Over
    }
}
