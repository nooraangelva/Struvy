using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Pathfollower : MonoBehaviour
{
    Node[] PathNode;
    public GameObject sticker;

    Sticker koodi;
    QuizManager kyssari;
    GetHaku haku;
    VideoPlayer videoPlayer;
    GameObject canvas;
    Vector3 CurrentPositionHolder;
    Vector3 previouspositionHolder;

    int CurrentNode;
    int matkaIndeksi;
    int y;
    int z;
    float siirtyma;
    int[] pisteet = {0, 10, 76, 171, 247, 297, 382, 458, 538, 614, 644, 703, 754, 830, 880, 962, 980};
    string[] value;
    string unesco;
    

    void Start()// alustetaan quiz ja stickkerin liike ja camera
    {
        kyssari = GameObject.Find("QuizManager").GetComponent<QuizManager>();
        sticker = GameObject.Find("Sticker");
        canvas = GameObject.Find("Canvas");
        koodi = sticker.GetComponent<Sticker>();
        PathNode = GetComponentsInChildren<Node>();
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        previouspositionHolder = PathNode[0].transform.position;
        CurrentPositionHolder = PathNode[1].transform.position;
        
        matkaIndeksi = 1; //testi
        //matkaIndeksi = Getint(string KeyName);

    }

    void Update()//liike ja kyssarin kaynnistys jos osuu kohalle
    {
        if (pisteet[matkaIndeksi] < koodi.matka)//ryhman etenemisen verran liikutaan
        {
            //unesco vai normi pisteet
            switch (pisteet[matkaIndeksi]) 
            {
            case 703:
                unesco = "Aavasaksa";
                StartCoroutine(ExampleCoroutine());
                matkaIndeksi++;
                previouspositionHolder = PathNode[matkaIndeksi-1].transform.position;
                CurrentPositionHolder = PathNode[matkaIndeksi].transform.position;
                Debug.Log(matkaIndeksi);
                //SetInt(string haku.r_id.ToString(), int pisteet[matkaIndeksi]);
                break;
            case 10:
                unesco = "Pyhtaa";
                StartCoroutine(ExampleCoroutine());
                matkaIndeksi++;
                previouspositionHolder = PathNode[matkaIndeksi-1].transform.position;
                CurrentPositionHolder = PathNode[matkaIndeksi].transform.position;
                Debug.Log(matkaIndeksi);
                //SetInt(string haku.r_id.ToString(), int pisteet[matkaIndeksi]);
                break;
            case 962:
                unesco = "Enontekio";
                StartCoroutine(ExampleCoroutine());
                matkaIndeksi++;
                previouspositionHolder = PathNode[matkaIndeksi-1].transform.position;
                CurrentPositionHolder = PathNode[matkaIndeksi].transform.position;
                Debug.Log(matkaIndeksi);
                //SetInt(string haku.r_id.ToString(), int pisteet[matkaIndeksi]);
                break;
            default:
                matkaIndeksi++;
                //kyssari.generateQuestion(); //muista public
                Time.timeScale = 0;//pause
                previouspositionHolder = PathNode[matkaIndeksi-1].transform.position;
                CurrentPositionHolder = PathNode[matkaIndeksi].transform.position;
                Debug.Log(matkaIndeksi);
                //SetInt(string haku.r_id.ToString(), int pisteet[matkaIndeksi]);
                break;
            }
        }
        //stickerin liike
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

    
       IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);
        Debug.Log(unesco);
        SceneManager.LoadScene(unesco);
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    

    
}
