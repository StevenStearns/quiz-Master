using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionsSO strQuestion;

    void Start()
    {
        questionText.text = strQuestion.GetQuestion();
    }

   
 
}
