using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LuoTunnus : MonoBehaviour
{
    PutHaku p_haku;
    
    GameObject info;
    GameObject u_info;

    Text u_kt;
    Text u_ss;
    Text u_ss2;

    private int response;
    private string[] value;

    
    void Start() //Määrittelee componentit
    {
        u_kt = GameObject.Find("Kayttajatunnus").GetComponent<Text>();
        u_ss = GameObject.Find("Salasana").GetComponent<Text>();
        u_ss2 = GameObject.Find("VarmistaSalasana").GetComponent<Text>();
        p_haku = GameObject.Find("Lahettaja").GetComponent<PutHaku>();
        info = GameObject.Find("Lahettaja");
        u_info = GameObject.Find("TunnusVirhe");
        value = new string[2];
    }

    public void TunnusLuo() //lähettää käskyn luoda tunnukset
    {
        if(u_ss == u_ss2)
        {
            value[0] = (string)u_kt.text;
            value[1] = (string)u_ss.text;
            value[2] = (string)u_ss2.text;
            p_haku.data = value;
            p_haku.id = 2;
            p_haku.siirtyma = "Paavalikko";
            
            p_haku.StartCoroutine("LocationHandler");

        }
        else
        {
            u_info.SetActive(true);
        }
    }

       void Update()
       {

       }
}
