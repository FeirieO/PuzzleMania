using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "New Question", menuName = "Quiz/Question") ]
public class QuizDataScriptable : ScriptableObject
{
    public List<QuestionData> questionData;
}

[System.Serializable]
public class QuestionData
{
    public string question;
    public string[] options;
    public int answerIndex;
}


