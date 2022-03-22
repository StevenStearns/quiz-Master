using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool blLoadNextQuestion;
    public float fltFillFraction;

    [SerializeField] float fltTimeToCompleteQuestion = 30f;
    [SerializeField] float fltTimeToShowCorrectAnswer = 10f;
    public bool blIsAnsweringQuestion;
    float fltTimerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        fltTimerValue = 0;
    }

    void UpdateTimer()
    {
        fltTimerValue -= Time.deltaTime;
        if(blIsAnsweringQuestion)
        {
            if(fltTimerValue > 0)
            {
                fltFillFraction = fltTimerValue / fltTimeToCompleteQuestion;
            }
            else
            {
                blIsAnsweringQuestion = false;
                fltTimerValue = fltTimeToCompleteQuestion;
            }
        }
        else
        {
            if(fltTimerValue > 0)
            {
                fltFillFraction = fltTimerValue / fltTimeToShowCorrectAnswer;
            }
            else
            {
                blIsAnsweringQuestion = true;
                fltTimerValue = fltTimeToCompleteQuestion;
                blLoadNextQuestion = true;
            }
        }
    } // UpdateTimer
}