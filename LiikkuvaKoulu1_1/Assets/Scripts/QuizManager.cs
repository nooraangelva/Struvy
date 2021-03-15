using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA; 
    public GameObject[] options;
    public int currentQuestion;
    string[] vastaukset;
    string[] oikein;
    string[] value;
    public Text QuestionTxt;
    GetHaku haku;


    private void Start()//kyssarin haun alustus
    {
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        value = new string[1];
        //Response vastaus = new Response();
       

        value[0] = haku.r_id.ToString();
        haku.data = value;
        haku.id = 1;
        
        //haku.StartCoroutine("GetServeri");
    }

    public void correct()//kyssarin poisto ja pelin jatkuminen
    {
        QnA.RemoveAt(currentQuestion);
       // generateQuestion();
    }

    void SetAnswers()// asettaa vastaukset kysymykselle
    {
        for (int i = 0; i < vastaukset.Length; i++)
        {
           /*TODO: oikein[i].GetComponent<AnswerScript>().isCorrect = false;
            oikein[i].transform.GetChild(0).GetComponent<Text>().text = vastaukset[i];

            if(currentQuestion.CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }*/
        }
    }

    void generateQuestion()//kyssarin haku
    {
        /*vastaus = JsonUtility.FromJson<Response>(haku.vastaus);
        currentQuestion = vastaus.kysymys;
        vastaukset = vastaus.vastaukset.Split("|");
        oikein = vastaus.oikein.Split("|");

        QuestionTxt.text = currentQuestion;
        SetAnswers();*/
    }
}
