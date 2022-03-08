using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuizQuestion", fileName = "New Question")]
public class QuestionsSO : ScriptableObject
{
    [TextArea(2,6)] 
    [SerializeField] string strQuestion = "Enter new question text here";

    public string GetQuestion()
    {
        return strQuestion;
    }
}


