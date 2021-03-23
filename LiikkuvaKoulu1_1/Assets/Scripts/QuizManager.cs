using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    //public List<QuestionsAndAnswers> QnA; 
    public GameObject[] options;
    PutHaku insertti;
    GetHaku haku;

    public Text QuestionTxt;

    public int currentQuestion;
    int oikein;
    int moneskoK = 0;
    string[] vastaukset;
    string[] value;




    private void Start()//kyssarin haun alustus
    {
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        insertti = GameObject.Find("Lahettaja").GetComponent<PutHaku>();

//        value[0] = haku.r_id.ToString();
        haku.data = value;
        haku.id = 5;
        
        //haku.StartCoroutine("GetServeri");
    }

    public void correct()//kyssarin poisto ja pelin jatkuminen
    {
        value = new string[1];
        value[0] = haku.r_id.ToString();
        haku.data = value;
        haku.id = 3;
        
        //haku.StartCoroutine("PutServeri");

        switch (SceneManager.GetActiveScene().name) 
        {
            case "Pelinakyma":
                //tuhoa tai jotai...
                break;
            default:
                if(moneskoK < 2)
                {
                    value[0] = haku.r_id.ToString();
                    haku.data = value;
                    haku.id = 5;
                    //haku.StartCoroutine("GetServeri");
                    //generateQuestion();
                }
                else{
                    SceneManager.LoadScene(6);
                }
                break;
        }
        


    }

    void SetAnswers()// asettaa vastaukset kysymykselle
    {
        for (int i = 0; i < vastaukset.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = vastaukset[i];

            if(oikein == i)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()//kyssarin haku
    {
        moneskoK++;
        vastaukset = haku.vastausKysymys.vastaukset.Split(char.Parse("|"));
        oikein = System.Array.IndexOf(haku.vastausKysymys.oikein.Split(char.Parse("|")), "1");
        QuestionTxt.text = haku.vastausKysymys.kysymys;
        SetAnswers();

    }
}
