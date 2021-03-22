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
    GameObject unescoPiste;
    Text infoText;
    Quaternion rotation;
    QuizManager kyssari;
    Quaternion target;

    public int info;
    float smooth = 0.3f;
    float angle = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        unescoInfo = GameObject.Find("UnescoInfo");
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
        GameObject.Find("UnescoInfo").SetActive(false);
        unescoPiste = GameObject.Find("UnescoPiste");
        unescoPiste.SetActive(false);
        info = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        target = Quaternion.Euler(0, angle, 0);
        // Dampen towards the target rotation
        Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, target,  Time.deltaTime * smooth);
        if(Quaternion.Euler(Camera.main.transform.localEulerAngles) == target){

            if(info == 0){

                switch (SceneManager.GetActiveScene().name) 
                {
                case "Aavasaksa":
                    unescoInfo.SetActive(true);
                    infoText.text = "Aavasaksa";
                    info = 1;
                    Camera.main.transform.localEulerAngles = new Vector3(0,-40,0);
                    Time.timeScale = 0;//pause
                    break;
                case "Pyhtaa":
                    unescoInfo.SetActive(true);
                    infoText.text = "Pyhtää";
                    info = 1;
                    Camera.main.transform.localEulerAngles = new Vector3(0,0,0);
                    Time.timeScale = 0;//pause
                    break;
                case "Enontekio":
                    unescoInfo.SetActive(true);
                    infoText.text = "Enontekio";
                    info = 1;
                    Camera.main.transform.localEulerAngles = new Vector3(0,0,0);
                    Time.timeScale = 0;//pause
                    break;
                }
            }
            else if(info == 1){
                unescoPiste.SetActive(true);
                kyssari = unescoPiste.GetComponent<QuizManager>();
                //kyssari.generateQuestion(); 
            }
        }
           
    }
}
