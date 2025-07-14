using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class MiniGameManager : MonoBehaviour
{
    public List<TMP_Dropdown> playerSelections;
    public List<string> correctOrder = new List<string> { "C", "B", "A" };

    public void SubmitSolution()
    {
        List<string> userInput = new List<string>();

        foreach (TMP_Dropdown d in playerSelections)
        {
            // Sanitize input: remove spaces and force uppercase
            string selected = d.options[d.value].text.Trim().ToUpper();
            Debug.Log("Selected: " + selected); // DEBUG
            userInput.Add(selected);
        }

        if (IsCorrect(userInput))
        {
            Debug.Log("Correct! Returning to maze...");
            PlayerPrefs.SetInt("MiniGameSuccess", 1);
            SceneManager.LoadScene("level one new scene"); // Must match Build Settings scene name
        }
        else
        {
            Debug.Log("❌ Incorrect! Try again.");
        }
    }

    private bool IsCorrect(List<string> input)
    {
        for (int i = 0; i < correctOrder.Count; i++)
        {
            string correct = correctOrder[i].Trim().ToUpper();
            if (input[i] != correct)
            {
                Debug.Log($"Mismatch at index {i}: Expected {correct}, Got {input[i]}");
                return false;
            }
        }
        return true;
    }
}