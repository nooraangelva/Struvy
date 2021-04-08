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
    GameObject unescoInfo;
    GameObject unescoPiste;
    Text infoText;
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

        unescoInfo = GameObject.Find("UnescoInfo");
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
        GameObject.Find("UnescoInfo").SetActive(false);
        unescoPiste = GameObject.Find("UnescoPiste");
        unescoPiste.SetActive(false);
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
            Debug.Log (target + "---"+ Camera.main.transform.rotation);

            if(Quaternion.Euler(Camera.main.transform.localEulerAngles) == target){

                if(info == 0){

                    switch (SceneManager.GetActiveScene().name) 
                    {
                    case "Aavasaksa":
                        unescoInfo.SetActive(true);
                        //infoText.text = "Aavasaksa";
                        info = 1;
                        Camera.main.transform.localEulerAngles = new Vector3(0,laAngle,0);
                        Time.timeScale = 0;//pause
                        break;
                    case "Pyhtaa":
                        unescoInfo.SetActive(true);
                        //infoText.text = "Pyhtää";
                        info = 1;
                        Camera.main.transform.localEulerAngles = new Vector3(0,laAngle,0);
                        Time.timeScale = 0;//pause
                        break;
                    case "Enontekio":
                        unescoInfo.SetActive(true);
                        //infoText.text = "Enontekio";
                        info = 1;
                        Camera.main.transform.localEulerAngles = new Vector3(0,laAngle,0);
                        Time.timeScale = 0;//pause
                        break;
                    }
                }
                else if(info == 1){
                    unescoPiste.SetActive(true);
                    kyssari = unescoPiste.GetComponent<QuizManager>();
                    kyssari.generateQuestion(); 
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
