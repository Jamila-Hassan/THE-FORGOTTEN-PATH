using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class MiniGame2 : MonoBehaviour
{
    public List<TMP_Dropdown> playerSelections;
    public List<string> correctOrder = new List<string> { "B", "A", "C" }; // Inorder Traversal
    public TextMeshProUGUI feedbackText;

    public void SubmitSolution()
    {
        List<string> userInput = new List<string>();

        foreach (TMP_Dropdown d in playerSelections)
        {
            string selected = d.options[d.value].text.Trim().ToUpper();
            Debug.Log("Selected: " + selected);
            userInput.Add(selected);
        }

        if (IsCorrect(userInput))
        {
            Debug.Log("✅ Correct! Loading maze...");
            PlayerPrefs.SetInt("MiniGameSuccess", 1);
            SceneManager.LoadScene("leveltwonewscene"); // Maze level 2
        }
        else
        {
            feedbackText.text = "❌ Incorrect! Try again.";
            Debug.Log("❌ Incorrect! Try again.");
        }
    }

    private bool IsCorrect(List<string> input)
    {
        for (int i = 0; i < correctOrder.Count; i++)
        {
            string expected = correctOrder[i].Trim().ToUpper();
            string actual = input[i].Trim().ToUpper();

            if (actual != expected)
            {
                Debug.Log($"Mismatch at index {i}: Expected [{expected}], Got [{actual}]");
                return false;
            }
        }
        return true;
    }
}
