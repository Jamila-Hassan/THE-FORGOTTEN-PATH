using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackPuzzle : MonoBehaviour
{
    public Text questionText;
    public InputField answerInput;
    public GameObject puzzlePanel;

    private string originalWord = "STACK";
    private string correctAnswer;

    void Start()
    {
        correctAnswer = ReverseWithStack(originalWord);
        questionText.text = $"Reverse this word using a stack: {originalWord}";
    }

    string ReverseWithStack(string word)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in word)
            stack.Push(c);

        string reversed = "";
        while (stack.Count > 0)
            reversed += stack.Pop();

        return reversed;
    }

    public void CheckAnswer()
    {
        if (answerInput.text.ToUpper() == correctAnswer)
        {
            Debug.Log("Correct!");
            puzzlePanel.SetActive(false);
            Time.timeScale = 1; // Resume the game
        }
        else
        {
            Debug.Log("Wrong! Try again.");
        }
    }
}
