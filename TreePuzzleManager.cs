using UnityEngine;
using UnityEngine.UI;

public class TreePuzzleManager : MonoBehaviour
{
    public GameObject puzzlePanel;
    public GameObject wallToOpen;
    public Button[] pathButtons;

    private string correctAnswer = "A-D-F"; // Expected answer path
    private string currentPath = "";

    void Start()
    {
        foreach (Button btn in pathButtons)
        {
            btn.onClick.AddListener(() => OnPathButtonClicked(btn.GetComponentInChildren<Text>().text));
        }
        puzzlePanel.SetActive(false);
    }

    public void ShowPuzzle()
    {
        puzzlePanel.SetActive(true);
        currentPath = "";
    }

    public void OnPathButtonClicked(string node)
    {
        currentPath += node + "-";
        if (currentPath == correctAnswer + "-")
        {
            OpenWall();
        }
    }

    void OpenWall()
    {
        puzzlePanel.SetActive(false);
        Destroy(wallToOpen); // Or animate open
    }
}
