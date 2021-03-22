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
        GameObject camera = GameObject.Find("Main Camera");
       
        matkaIndeksi = 1;
        //matkaIndeksi = Getint(string KeyName);

        //videon pyorityksen alustus
        videoPlayer = camera.GetComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        //videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        //videoPlayer.targetCameraAlpha = 0.5F;// This will cause our Scene to be visible through the video being played.
        videoPlayer.url = "Assets/video/wtp1.mp4";
        videoPlayer.isLooping = true;
        videoPlayer.Prepare();

    }

    void Update()//liike ja kyssarin kaynnistys jos osuu kohalle
    {
        if (pisteet[matkaIndeksi] < koodi.matka)//ryhman etenemisen verran liikutaan
        {
            //unesco vai normi pisteet
            switch (pisteet[matkaIndeksi]) 
            {
            case 703:
                //canvas.SetActive(false);
                StartCoroutine(AsyncScene("Aavasaksa"));
                matkaIndeksi++;
                previouspositionHolder = PathNode[matkaIndeksi-1].transform.position;
                CurrentPositionHolder = PathNode[matkaIndeksi].transform.position;
                Debug.Log(matkaIndeksi);
                //SetInt(string haku.r_id.ToString(), int pisteet[matkaIndeksi]);
                
                videoPlayer.Play();

                break;
            case 10:
                //canvas.SetActive(false);
                //StartCoroutine(AsyncScene("Pyhtaa"));
                matkaIndeksi++;
                previouspositionHolder = PathNode[matkaIndeksi-1].transform.position;
                CurrentPositionHolder = PathNode[matkaIndeksi].transform.position;
                Debug.Log(matkaIndeksi);
                //SetInt(string haku.r_id.ToString(), int pisteet[matkaIndeksi]);
                videoPlayer.Play();
                break;
            case 962:
                //canvas.SetActive(false);
                StartCoroutine(AsyncScene("Enontekio"));
                matkaIndeksi++;
                previouspositionHolder = PathNode[matkaIndeksi-1].transform.position;
                CurrentPositionHolder = PathNode[matkaIndeksi].transform.position;
                Debug.Log(matkaIndeksi);
                //SetInt(string haku.r_id.ToString(), int pisteet[matkaIndeksi]);
                videoPlayer.Play();
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

    IEnumerator AsyncScene(string scene)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
