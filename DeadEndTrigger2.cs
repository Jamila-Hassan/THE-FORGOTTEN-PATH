using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadEndTrigger2 : MonoBehaviour
{
    public GameObject miniGameUI;
    public string wallID; // Unique identifier for this dead-end wall
    public Transform respawnPoint; // Where to respawn after mini-game

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            miniGameUI.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            // Save wall ID and position
            PlayerPrefs.SetString("DeadEndWallID", wallID);
            PlayerPrefs.SetFloat("RespawnX", respawnPoint.position.x);
            PlayerPrefs.SetFloat("RespawnY", respawnPoint.position.y);
            PlayerPrefs.SetFloat("RespawnZ", respawnPoint.position.z);

            Debug.Log($"Dead-end triggered: {wallID}");
        }
    }

    // ✅ This will now show up in Unity's Button OnClick() menu
    public void HandleClickYes()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        SceneManager.LoadScene("DataStructure2");
    }

    public void HandleClickNo()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        miniGameUI.SetActive(false);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.TriggerGameOver();
        }
        else
        {
            Debug.LogWarning("GameManager not found.");
        }
    }
}
