using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class Unesco : MonoBehaviour
{
    //QuizManager kyssari;
    GetHaku haku;
    GameObject unescoInfo;
    Text infoText;
    Quaternion OrgRotation;
    Quaternion rotation;
    //Camera camera;
    QuizManager kyssari;
    Quaternion target;

    public int info;
    public float rotationSpeed=0.1f;
    float smooth = 5.0f;
    float angle = 100.0f;
    float tiltAroundZ;

    // Start is called before the first frame update
    void Start()
    {
        kyssari = GameObject.Find("UnescoPiste").GetComponent<QuizManager>();
        unescoInfo = GameObject.Find("UnescoInfo");
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
        OrgRotation = Camera.main.transform.rotation;
        unescoInfo.SetActive(false);
        GameObject.Find("UnescoPiste").SetActive(false);
        info = 0;
        Debug.Log("HakunaMatata");
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("HakunaMatata vol.2");
        target = Quaternion.Euler(0, angle, 0);
        // Dampen towards the target rotation
        Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, target,  Time.deltaTime * smooth);

        if(OrgRotation == rotation){

            if(info == 0){

                switch (SceneManager.GetActiveScene().name) 
                {
                case "Aavasaksa":
                    unescoInfo.SetActive(true);
                    infoText.text = "Aavasaksa";
                    Debug.Log("kaakkaaaavalla");
                    info = 1;
                    //camera.transform.eulerAngles.y = 0;
                    Time.timeScale = 0;//pause
                    break;
                case "Pyhtaa":
                    unescoInfo.SetActive(true);
                    infoText.text = "Pyhtää";
                    Debug.Log("kaakkaapylly");
                    info = 1;
                    //camera.transform.eulerAngles.y = 0;
                    Time.timeScale = 0;//pause
                    break;
                case "Enontekio":
                    unescoInfo.SetActive(true);
                    infoText.text = "Enontekio";
                    Debug.Log("kaakkaaenon");
                    info = 1;
                    //camera.transform.eulerAngles.y = 0;
                    Time.timeScale = 0;//pause
                    break;
                }
            }
            else if(info == 1){
                //kyssari.generateQuestion(); 
            }
        }
        

           
    }
}
