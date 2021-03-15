using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfollower : MonoBehaviour
{
    Node[] PathNode;
    public GameObject sticker;

    Sticker koodi;
    QuizManager kyssari;
    GetHaku haku;

    float Timer;
    Vector3 CurrentPositionHolder;
    Vector3 previouspositionHolder;
    int CurrentNode;
    int matkaIndeksi;
    int y;
    int z;
    float siirtyma;
    int[] pisteet = {0, 10, 76, 171, 247, 297, 382, 458, 538, 614, 644, 754, 830, 880, 980};
    string[] value;

    

    void Start()// alustetaan quiz ja stickkerin liike
    {
        kyssari = GameObject.Find("QuizManager").GetComponent<QuizManager>();
        sticker = GameObject.Find("Sticker");
        koodi = sticker.GetComponent<Sticker>();
        PathNode = GetComponentsInChildren<Node>();
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        previouspositionHolder = PathNode[0].transform.position;
        CurrentPositionHolder = PathNode[1].transform.position;

        value[0] = haku.r_id.ToString();
        haku.data = value;
        haku.id = 1;
        
        haku.StartCoroutine("GetServeri");
       

        //CheckNode();
        matkaIndeksi = 1;
        y = 2;// haettu tietokannasta käydyt pisteet - kesken

        //for(z = 0; z < vastaus.pisteet; z++)//poistetaan kaydyt pisteet
        for(z = 0; z < y; z++)//poistetaan kaydyt pisteet
        {
           // pisteet.RemoveAt(z);
        }
        
    }
/*
    void CheckNode()//pisteen vaihto
    {
        Timer = 0;
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
    }
*/
    void Update()//liike ja kyssarin kaynnistys jos osuu kohalle
    {
        if (pisteet[matkaIndeksi] < koodi.matka)//ryhman etenemisen verran liikutaan
        {
            matkaIndeksi++;

            //kyssari.generateQuestion(); //muista public
            Time.timeScale = 0;//pause
            

            /*if(sticker.transform.position != CurrentPositionHolder)//jos ei oo vielä pisteeseen paassy sticker
            {
                
                Debug.Log(Timer+"="+Time.deltaTime+"*"+0.00771f);
            }
            else// jos on pisteen kohalla, pisteen vaihto
            {
                if (CurrentNode < PathNode.Length -1)//tahtays pisteen vaihto
                {
                        CurrentNode++;
                        CheckNode();
                       // Debug.Log("kakkaa3");
                }
            }*/
        }

        siirtyma = 10 / pisteet[matkaIndeksi];
        sticker.transform.position = Vector3.Lerp(previouspositionHolder, CurrentPositionHolder, siirtyma);

    }
}
