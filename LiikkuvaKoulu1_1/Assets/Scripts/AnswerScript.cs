// Scene: Kaikissa pelisceneissä 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    QuizManager quizManager;
    PutHaku insertti;
    GetHaku haku;
    public Unesco boss;

    string[] value;


    public void Start()
    {
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        insertti = GameObject.Find("Lahettaja").GetComponent<PutHaku>();
        quizManager = GameObject.Find("Lahettaja").GetComponent<QuizManager>();
    }

    public void Answer()//ilmoittaa meniko vastaus oikein vai vaarin
    {

        if(isCorrect)
        {
            Debug.Log("Vastauksesi oli oikein.");
            
            value = new string[1];
            value[0] = haku.r_id.ToString();
            value[1] = "5";
            insertti.data = value;
            insertti.id = 4;
            boss.oikeinCanvas.SetActive(true);
            insertti.StartCoroutine("PutServeri");
            quizManager.correct();

        }
        else
        {
            quizManager.correct();
            boss.vaarinCanvas.SetActive(true);
            Debug.Log("Vastauksesi oli väärin.");
        }
    }
}

