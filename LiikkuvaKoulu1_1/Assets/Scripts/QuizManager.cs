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
    public Unesco boss;
    GameObject quisManager;
    public GameObject quizCanvas;
    PutHaku insertti;
    GetHaku haku;
    public GameObject vaarinCanvas;
    public GameObject oikeinCanvas;
    public Text QuestionTxt;

    int oikein;
    int moneskoK = 0;
    string[] vastaukset;
    string qCanvasNimi;


    private void Start()//kyssarin haun alustus
    {

        quizCanvas.SetActive(false);

        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        insertti = GameObject.Find("Lahettaja").GetComponent<PutHaku>();
        quisManager = GameObject.Find("QuizManager");


        switch (SceneManager.GetActiveScene().name) 
        {
            case "Pelinakyma":
                Debug.Log("Q");
                break;

            default:
                KHaku();
                break;
        }

    }

    public void correct()//kyssarin poisto ja pelin jatkuminen
    {
        
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
        quizCanvas.SetActive(true);
        vastaukset = haku.vastausKysymys.vastaukset.Split(char.Parse("|"));
        oikein = System.Array.IndexOf(haku.vastausKysymys.oikein.Split(char.Parse("|")), "1");
        //QuestionTxt.text = haku.vastausKysymys.kysymys;
        //SetAnswers();
        Debug.Log("generate Questin");
    }

    public void KHaku(){

        string[] value = {haku.r_id.ToString()};
        haku.data = value;
        haku.id = 5;
        //haku.StartCoroutine("GetServeri");
    }

    public void Vaarinnappi()
    {
        switch (SceneManager.GetActiveScene().name) 
        {
            case "Pelinakyma":
                vaarinCanvas.SetActive(false);
                quizCanvas.SetActive(false);
                Time.timeScale = 1;
                break;

            default:
                SceneManager.LoadScene("Pelinakyma");
                break;
        }
       
    }

    public void Oikeinnappi()
    {
        switch (SceneManager.GetActiveScene().name) 
        {
            case "Pelinakyma":
                oikeinCanvas.SetActive(false);
                //quisManager.SetActive(false);
                quizCanvas.SetActive(false);
                Time.timeScale = 1;
                break;

            default:
                SceneManager.LoadScene("Pelinakyma");
                break;
        }
       
    }
}
