using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class KirjauduSisaan : MonoBehaviour
{
    GetHaku haku;
    GameObject info;

    Text kt;
    Text ss;

    private int response;
    private string[] value;

    void Start() //Määritellään componentit
    {
        kt = GameObject.Find("Kayttajatunnus").GetComponent<Text>();
        ss = GameObject.Find("Salasana").GetComponent<Text>();
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        value = new string[1];
    }

    public void Kirjaudu() //Lähettää käskyn tarkistaa tunnukset
    {

        value[0] = (string)kt.text;
        value[1] = (string)ss.text;
        haku.data = value;
        haku.id = 1;
        haku.siirtyma = "Paavalikko";
        
        haku.info = GameObject.Find("KirjauduVirhe");
        haku.StartCoroutine("LocationHandler");
    }

    void Update()
    {
        
    }
}
