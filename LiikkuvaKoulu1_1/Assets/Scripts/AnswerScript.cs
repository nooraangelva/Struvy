using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Vastaus meni oikein");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Olet tyhmä mene kämpille");
            quizManager.correct();
        }
    }
}