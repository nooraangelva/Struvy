using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    GetHaku haku;

    string[] value;

    public void Answer()//ilmoittaa meniko vastaus oikein vai vaarin
    {
        if(isCorrect)
        {
            Debug.Log("Vastauksesi oli oikein.");
            
            value = new string[1];
            value[0] = haku.r_id.ToString();
            value[1] = "5";
            haku.data = value;
            haku.id = 4;
            
            //haku.StartCoroutine("PutServeri");
            quizManager.correct();

        }
        else
        {
            Debug.Log("Vastauksesi oli väärin.");
            quizManager.correct();
        }
    }
}