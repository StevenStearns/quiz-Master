using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionsSO> questions = new List<QuestionsSO>();
    QuestionsSO strCurrentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int intCorrectAnswerIndex;
    bool blHasAnsweredEarly;

    [Header("Button Color")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timer")]
    
    [SerializeField] Image TimerImage;
    Timer timer;    

    void Start()
    {
        timer = FindObjectOfType<Timer>();
      
    }

    void Update() 
    {
        TimerImage.fillAmount = timer.fltFillFraction;
        if(timer.blLoadNextQuestion)
        {
            blHasAnsweredEarly = false;
            GetNextQuestion();
            timer.blLoadNextQuestion = false;
        }
        else if(!blHasAnsweredEarly && !timer.blIsAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);

        }
    }

    void GetNextQuestion()
    {
        if(questions.Count >0 )
        {
          SetButtonState(true);
          SetDefaultButtonSprites();
          GetRandomQuestion();
          DisplayQuestion();   
        }
       
    }

    void GetRandomQuestion()
    {
        int intIndex = Random.Range(0, questions.Count);
        strCurrentQuestion = questions[intIndex];
        
        if(questions.Contains(strCurrentQuestion))
        {
            questions.Remove(strCurrentQuestion);
        }
    }

    void DisplayQuestion()
    {
        questionText.text = strCurrentQuestion.GetQuestion();

        for(int intI = 0; intI < answerButtons.Length; intI++)
        {

            TextMeshProUGUI buttonText = answerButtons[intI].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = strCurrentQuestion.GetAnswer(intI);
        }
    }

    void SetButtonState(bool state)
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
        blHasAnsweredEarly = true;
       DisplayAnswer(intIndex);
    
        SetButtonState(false);
        timer.CancelTimer();
    } //Onselectbutton

    void DisplayAnswer(int intIndex)
    {
         Image buttonImage;

        if(intIndex == strCurrentQuestion.GetAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[intIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {

            intCorrectAnswerIndex = strCurrentQuestion.GetAnswerIndex();
            string strCorrectAnswer = strCurrentQuestion.GetAnswer(intCorrectAnswerIndex);
            questionText.text = "Sorry, the correct answer was;\n" + intCorrectAnswerIndex;
            buttonImage = answerButtons[intCorrectAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;    
        }
    }
 
}
