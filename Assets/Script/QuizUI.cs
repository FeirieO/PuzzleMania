using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private Text questionText;
    [SerializeField] private Button[] optionButtons;
    [SerializeField] private QuizDataScriptable quizData;

    private QuestionData currentQuestion;
    private int currentQuestionIndex;
    private int playerScore;

    private void Start()
    {
        playerScore = 0;
        currentQuestionIndex = -1;
        DisplayNextQuestion();
    }

    public void DisplayNextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < quizData.questionData.Count)
        {
            currentQuestion = quizData.questionData[currentQuestionIndex];

            questionText.text = currentQuestion.question;

            for (int i = 0; i < optionButtons.Length; i++)
            {
                optionButtons[i].GetComponentInChildren<Text>().text = currentQuestion.options[i];
            }
        }
        else
        {
            EndQuiz();
        }
    }

    public void CheckAnswer(int answerIndex)
    {
        if (answerIndex == currentQuestion.answerIndex)
        {
            playerScore++;
        }

        DisplayNextQuestion();
    }

    private void EndQuiz()
    {
        Debug.Log("Quiz complete! Score: " + playerScore);
    }

}
