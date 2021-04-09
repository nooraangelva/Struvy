//Scene: Pelinakyma

// Toiminta: Kaiken hallinta scenessä. Big Boss :)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Pathfollower : MonoBehaviour
{
    Node[] PathNode;
    public GameObject sticker;
    public GameObject vaarinCanvas;
    public GameObject oikeinCanvas;
    public GameObject quissari;
    public GameObject quizCanvas;

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
    

    void Start()// alustetaan quiz ja stickerin liike
    {
        kyssari = GameObject.Find("QuizManager").GetComponent<QuizManager>();
        quissari = GameObject.Find("QuizManager");
        quizCanvas = GameObject.Find("PikkuPiste");
        sticker = GameObject.Find("Sticker");
        canvas = GameObject.Find("Canvas");
        vaarinCanvas = GameObject.Find("Vaarin");
        oikeinCanvas = GameObject.Find("Oikein");
        koodi = sticker.GetComponent<Sticker>();
        PathNode = GetComponentsInChildren<Node>();
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        previouspositionHolder = PathNode[0].transform.position;
        CurrentPositionHolder = PathNode[1].transform.position;
        
        matkaIndeksi = 1; //testi
        //matkaIndeksi = Getint(string KeyName);
        oikeinCanvas.SetActive(false);
        vaarinCanvas.SetActive(false);
        quissari.SetActive(false);
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
                quissari.SetActive(true);
                kyssari.generateQuestion(); //muista public
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
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        // odottaa 10 sec
        yield return new WaitForSeconds(10);
        Debug.Log(unesco);
        SceneManager.LoadScene(unesco);
 
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    

    
}
