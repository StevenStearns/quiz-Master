using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{

    int intCorrectAnswers = 0;
    int intQuestionsSeen = 0;

  public int GetCorrectAnswers()
  {
      return intCorrectAnswers;
  } // GetCorrectAnswers

  public void IncrementCorrectAnswers()
  {
      intCorrectAnswers++;
  } // IncrementCorrectAnswers

  public int GetQuestionSeeen()
  {
      return intQuestionsSeen;
  }

  public void IncrementQuestionsSeen()
  {
      intQuestionsSeen++;
  }

  public int CalculateScore()
  {
      return Mathf.RoundToInt(intCorrectAnswers / (float)intQuestionsSeen * 100);
  }
}


