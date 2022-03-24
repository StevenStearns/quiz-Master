using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuizQuestion", fileName = "New Question")]
public class QuestionsSO : ScriptableObject
{
    [TextArea(2,6)] 
    [SerializeField] string strQuestion = "Enter new question text here";
    [SerializeField] string[] stranswers = new string[4];
    [SerializeField] int intCorrectAnswerIndex;

    public string GetQuestion()
    {
        return strQuestion;
    }
    
    public int GetAnswerIndex()
    {
        return intCorrectAnswerIndex;
    }

    public string GetAnswer(int intindex)
    {
        return stranswers[intindex];
    }
} // QuestionSO


