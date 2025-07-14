using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public string levelToLoad = "level one new scene"; // Name of your Level 1 scene

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Exit()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();
    }
}
