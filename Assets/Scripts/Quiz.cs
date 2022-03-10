using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionsSO strQuestion;
    [SerializeField] GameObject[] answerButtons;
    int intCorrectAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    async void Start()
    {
        GetNextQuestion();
       //DisplayQuestion();
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        questionText.text = strQuestion.GetQuestion();

        for(int intI = 0; intI < answerButtons.Length; intI++)
        {

            TextMeshProUGUI buttonText = answerButtons[intI].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = strQuestion.GetAnswer(intI);
        }
    }

    async void SetButtonState(bool state)
    {
        for(int intI = 0; intI < answerButtons.Length; intI++)
        {
            Button btnButton = answerButtons[intI].GetComponent<Button>();
            btnButton.interactable = state;
        }
    }

    void SetDefaultButtonSprites()
    {
        for(int intI = 0; intI < answerButtons.Length; intI++)
        {
            Image buttonImage = answerButtons[intI].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

    public void OnAnswerSelected(int intIndex)
    {
        Image buttonImage;

        if(intIndex == strQuestion.GetAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[intIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {

            intCorrectAnswerIndex = strQuestion.GetAnswerIndex();
            string strCorrectAnswer = strQuestion.GetAnswer(intCorrectAnswerIndex);
            questionText.text = "Sorry, the correct answer was;" + intCorrectAnswerIndex;
            buttonImage = answerButtons[intCorrectAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        SetButtonState(false);
    } //Onselectbutton

   
 
}
