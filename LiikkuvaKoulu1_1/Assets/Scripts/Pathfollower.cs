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
       
        matkaIndeksi = 1;
        //matkaIndeksi = Getint(string KeyName);
        
    }

    void Update()//liike ja kyssarin kaynnistys jos osuu kohalle
    {
        if (pisteet[matkaIndeksi] < koodi.matka)//ryhman etenemisen verran liikutaan
        {
            matkaIndeksi++;

            //kyssari.generateQuestion(); //muista public
            Time.timeScale = 0;//pause

            previouspositionHolder = PathNode[matkaIndeksi-1].transform.position;
            CurrentPositionHolder = PathNode[matkaIndeksi].transform.position;
            Debug.Log(matkaIndeksi);
            //SetInt(string KeyName, int Value)
        }

        siirtyma = ((float)koodi.matka-pisteet[matkaIndeksi-1]) / ((float)pisteet[matkaIndeksi]-pisteet[matkaIndeksi-1]);
        sticker.transform.position = Vector3.Lerp(previouspositionHolder, CurrentPositionHolder, siirtyma);
        
    }

    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public int Getint(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
}
