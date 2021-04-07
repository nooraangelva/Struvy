// Scene: Kaikissa pelisceneissä
// Toiminta: Kaikkiin kysymyksiin. KysymysBoss

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public GameObject[] options;
    GameObject quisManager;
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
        quisManager = GameObject.Find("QuizManager");

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
                quisManager.SetActive(false);
                Time.timeScale = 1;
                break;

            default:
                    SceneManager.LoadScene(6);
                break;
        }
    }

    public void SetAnswers()// asettaa vastaukset kysymykselle
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

    public void generateQuestion()//kyssarin haku
    {
        moneskoK++;
        vastaukset = haku.vastausKysymys.vastaukset.Split(char.Parse("|"));
        oikein = System.Array.IndexOf(haku.vastausKysymys.oikein.Split(char.Parse("|")), "1");
        QuestionTxt.text = haku.vastausKysymys.kysymys;
        SetAnswers();

    }
}
