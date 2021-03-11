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
    public Text QuestionTxt;
    GetHaku haku;


    private void Start()
    {
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
       // generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < vastaukset.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = vastaukset[i];

            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
       // currentQuestion = Random.Range(0, QnA.Count);
        value[0] = (string)kt.text;
        value[1] = (string)ss.text;
        haku.data = value;
        haku.id = 1;

        haku.StartCoroutine("LocationHandler");
        currentQuestion = "";
        vastaukset ="";

        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers();
    }
}
