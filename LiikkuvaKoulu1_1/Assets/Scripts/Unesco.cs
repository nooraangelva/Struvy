//Scene: Unescoissa
//Toiminta: Unescojen Big Boss

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using UnityEngine.Video;

public class Unesco : MonoBehaviour
{
    //QuizManager kyssari;
    GetHaku haku;
    public GameObject unescoInfo;
    GameObject unescoPiste;
    public GameObject quizG;
    Text infoText;
    public GameObject qTausta;
    Quaternion rotation;
    QuizManager kyssari;
    Quaternion target;
    VideoPlayer videoPlayer;
    public GameObject vaarinCanvas;
    public GameObject oikeinCanvas;

    public int info;
    float smooth = 0.3f;
    float loAngle;
    float laAngle;
    public double time;
    public double currentTime;

    void Start() // hakee gameobjectit ja kutsuu videoplayeria
    {

        switch (SceneManager.GetActiveScene().name) 
        {
        case "Aavasaksa":
            loAngle = 25;
            laAngle = -40;
            break;
        case "Pyhtaa":
            loAngle = 215;
            laAngle = 180;
            break;
        case "Enontekio":
            loAngle =  -145;
            laAngle = -220;     
            break;
        }
        
        vaarinCanvas = GameObject.Find("Vaarin");
        oikeinCanvas = GameObject.Find("Oikein");
        //unescoInfo = GameObject.Find("UnescoInfo");
        //quizG = GameObject.Find("GuizManager");
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
        unescoInfo.SetActive(false);
        unescoPiste = GameObject.Find("UnescoPiste");
        oikeinCanvas.SetActive(false);
        vaarinCanvas.SetActive(false);
        //qTausta.SetActive(false);
        info = 0;
        VideoPlayer();   
    }

    void Update() //Poistaa kameran ja näyttää infon jonka jälkeen käynnistää Quismanagerin 
    {
        if (videoPlayer != null){
            currentTime = videoPlayer.time;
        }
        
        if (currentTime >= time) {

            
            Destroy(videoPlayer);


            //videon poisto
        
            target = Quaternion.Euler(0, loAngle, 0);
            Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, target,  Time.deltaTime * smooth);
            //Debug.Log (target + "---"+ Camera.main.transform.rotation);

            if(Camera.main.transform.rotation == target){

                if(info == 0){

                    switch (SceneManager.GetActiveScene().name) 
                    {
                    case "Aavasaksa":
                        unescoInfo.SetActive(true);
                        info = 1;
                        Camera.main.transform.localEulerAngles = new Vector3(0,laAngle,0);
                        Time.timeScale = 0;//pause
                        break;
                    case "Pyhtaa":
                        unescoInfo.SetActive(true);
                        info = 1;
                        Camera.main.transform.localEulerAngles = new Vector3(0,laAngle,0);
                        Time.timeScale = 0;//pause
                        break;
                    case "Enontekio":
                        unescoInfo.SetActive(true);
                        info = 1;
                        Camera.main.transform.localEulerAngles = new Vector3(0,laAngle,0);
                        Time.timeScale = 0;//pause
                        break;
                    }
                }
                else if(info == 1){
                    Debug.Log("quiz");
                    qTausta.SetActive(true);
                    quizG.GetComponent<QuizManager>().generateQuestion();
                    Time.timeScale = 0;
                }
            }
        }     
    }

    

    public void VideoPlayer(){

        //videon pyorityksen alustus
        videoPlayer = GameObject.Find("Main Camera").AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        //videoPlayer.targetCameraAlpha = 0.5F;// This will cause our Scene to be visible through the video being played.
        videoPlayer.url = "Assets/video/wtp1.mp4";
        videoPlayer.isLooping = false;
        videoPlayer.Prepare();
        time = videoPlayer.length;
        videoPlayer.Play();
    }
}
