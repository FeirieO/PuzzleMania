using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;

public class QuizManager : MonoBehaviour
{
    private Text scoreText;
    public Text questionText;
    public Button[] optionButtons;
    public Button nextButton;
    public GameObject GameOverPanel;

    private List<Question> questionList;
    private int currentQuestionIndex = 0;
    private int score = 0;

    private void Start()
    {
        score = 0;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        LoadQuestionsFromJSON();
        DisplayQuestion(currentQuestionIndex);
    }

    private void LoadQuestionsFromJSON()
    {
        // Load JSON file from assets folder
        TextAsset jsonFile = Resources.Load<TextAsset>("quiz");

        // Deserialize JSON data into Question objects
        questionList = JsonUtility.FromJson<QuestionList>(jsonFile.text).questions;
    }

    private void DisplayQuestion(int index)
    {
        // Update UI with current question and options
        Question question = questionList[index];
        questionText.text = question.question;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].GetComponentInChildren<Text>().text = question.options[i];
            int optionIndex = i; // Save option index to pass to button click event handler
            optionButtons[i].onClick.RemoveAllListeners(); // Clear previous event handlers
            optionButtons[i].onClick.AddListener(() => SelectOption(optionIndex));
        }

        nextButton.gameObject.SetActive(false); // Disable next button until an option is selected
    }

    private void SelectOption(int index)
    {
        // Check if selected option is correct
        Question question = questionList[currentQuestionIndex];
        if (question.options[index] == question.correctAnswer)
        {
            Debug.Log("Correct!");
            // Increment score or do something else to indicate correct answer
            optionButtons[index].GetComponent<Image>().color = Color.green;
            score += 5;
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.Log("Incorrect!");
            // Do something else to indicate incorrect answer
            optionButtons[index].GetComponent<Image>().color = Color.red;
            // Update UI with correct answer indication (e.g., green color)
            int correctAnswerIndex = System.Array.IndexOf(question.options, question.correctAnswer);
            optionButtons[correctAnswerIndex].GetComponent<Image>().color = Color.green;
            // Update score or do something else to indicate incorrect answer
        }

        // Enable next button and disable option buttons
        nextButton.gameObject.SetActive(true);
        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].interactable = false;
        }
    }

    public void NextQuestion()
    {
        // Reset option button colors
        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].GetComponent<Image>().color = Color.white;
        }

        // Increment question index and display next question
        currentQuestionIndex++;
        if (currentQuestionIndex < questionList.Count)
        {
            for (int i = 0; i < optionButtons.Length; i++)
            {
                optionButtons[i].interactable = true; // Enable option buttons for next question
            }
            DisplayQuestion(currentQuestionIndex);
        }
        else
        {
            Debug.Log("Quiz finished!");
            GameOverPanel.SetActive(true);
            scoreText.text = "Quiz Finished! Score: " + score;
        }
        nextButton.gameObject.SetActive(false); // Disable next button for next question
    }
}

[System.Serializable]
public class Question
{
    public string question;
    public string[] options;
    public string correctAnswer;
}

[System.Serializable]
public class QuestionList
{
    public List<Question> questions;
}
