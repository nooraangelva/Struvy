using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer()//ilmoittaa meniko vastaus oikein vai vaarin
    {
        if(isCorrect)
        {
            Debug.Log("Vastauksesi oli oikein.");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Vastauksesi oli väärin.");
            quizManager.correct();
        }
    }
}