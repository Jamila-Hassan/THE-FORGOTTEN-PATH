using UnityEngine;

public class MiniGameBootstrap : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f; // Ensure the game is not paused
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
