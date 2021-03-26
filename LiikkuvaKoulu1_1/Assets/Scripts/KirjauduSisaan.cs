// Scene: KirjauduValikko

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class KirjauduSisaan : MonoBehaviour
{
   
    GameObject info;
    GetHaku haku;

    Text kt;
    Text ss;

    private int response;
    private string[] value;
    public int r_id;


    void Start() //Määritellään componentit
    {
        kt = GameObject.Find("Kayttajatunnus").GetComponent<Text>();
        ss = GameObject.Find("Salasana").GetComponent<Text>();
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        value = new string[1];
        info = GameObject.Find("KirjauduVirhe");

    }

    public void Kirjaudu() //Lähettää käskyn tarkistaa tunnukset
    {

        value[0] = (string)kt.text;
        value[1] = (string)ss.text;
        haku.data = value;
        haku.id = 1;
        haku.siirtyma = "PaavalikkoMenu";
        
        haku.StartCoroutine("GetServeri");

        if(!haku.vastausTunnus.r_id.Contains(""))
        {
            Debug.Log("Paavalikkoon");
        }
        else
        {
            haku.info.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
