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
    public GameObject oikeinCanvas;
    public GameObject vaarinCanvas;
    
    public Text qPisteet;

    string pisteet;



    public void Start()
    {
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        insertti = GameObject.Find("Lahettaja").GetComponent<PutHaku>();
        quizManager = GameObject.Find("QuizManager").GetComponent<QuizManager>();
    }

    public void Answer()//ilmoittaa meniko vastaus oikein vai vaarin
    {

        if(isCorrect)
        {
            Debug.Log("Vastauksesi oli oikein.");
            switch (SceneManager.GetActiveScene().name) 
            {
                case "Pelinakyma":
                    pisteet = "5";
                    qPisteet.text = "Sait lisäkilometrejä: "+pisteet+"!!";
                    break;
                default:
                    pisteet = "10";
                    qPisteet.text = "Sait lisäkilometrejä: "+pisteet+"!!";
                    break;
            }

            string[] value = {haku.r_id.ToString(), pisteet};
            insertti.data = value;
            insertti.id = 4;
            oikeinCanvas.SetActive(true);
            insertti.StartCoroutine("PutServeri");
            //quizManager.correct();

        }
        else
        {
            //quizManager.correct();
            vaarinCanvas.SetActive(true);
            Debug.Log("Vastauksesi oli väärin.");
        }
    }
}

