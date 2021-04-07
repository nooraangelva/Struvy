// Scene: Kaikissa pelisceneissä 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    //GameObject oikein;
    //GameObject vaarin;
    GetHaku haku;
    public Unesco boss;

    string[] value;


    public void Start()
    {

    }

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
            boss.oikeinCanvas.SetActive(true);
            
            //haku.StartCoroutine("PutServeri");
            quizManager.correct();

        }
        else
        {
            Debug.Log("Vastauksesi oli väärin.");
            quizManager.correct();
            boss.vaarinCanvas.SetActive(true);
        }
    }

    public void nappi()
    {
        if(SceneManager.GetActiveScene().name == "Pelinakyma")
        {
            boss.vaarinCanvas.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("Pelinakyma");
        }
    }
}