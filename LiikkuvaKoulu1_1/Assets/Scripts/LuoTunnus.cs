//Scene: TunnusMenu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LuoTunnus : MonoBehaviour
{
    PutHaku p_haku;
    GetHaku haku;
    GameObject info;
    GameObject u_info;
    GameObject u_info2;

    public Text u_kt;
    public Text u_ss;
    public Text u_ss2;

    private int response;

    
    void Start() //Määrittelee componentit
    {
        //u_kt = GameObject.Find("Kayttajatunnus").GetComponent<Text>();
        //u_ss = GameObject.Find("Salasana").GetComponent<Text>();
        //u_ss2 = GameObject.Find("VarmistaSalasana").GetComponent<Text>();
        p_haku = GameObject.Find("Lahettaja").GetComponent<PutHaku>();
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        info = GameObject.Find("Lahettaja");
        u_info = GameObject.Find("TunnusVirhe");
        u_info2 = GameObject.Find("TunnusVarattu");

        u_info.SetActive(false);
        u_info2.SetActive(false);
   
    }

    public void TunnusLuo() //lähettää käskyn luoda tunnukset
    {
        if(u_ss.text == u_ss2.text)
        {
            string[] value = {u_kt.text.ToString(), u_ss.text.ToString()};
            p_haku.data = value;
            p_haku.id = 2;
            p_haku.siirtyma = "KirjauduMenu";
            
            p_haku.StartCoroutine("PutServeri");
            StartCoroutine(Odotus());
            
            
        }

        else
        {
            u_info.SetActive(true);
        }

    }

       void Update()
       {

       }

    IEnumerator Odotus()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        // odottaa 2 sec
        yield return new WaitForSeconds(2);
        
 
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        Debug.Log(p_haku.vastaus);

        if(p_haku.vastaus.Contains("200"))
        {
            Debug.Log("kirjautumine");
            string[] value = {u_kt.text.ToString(), u_ss.text.ToString()};
            haku.data = value;
            haku.id = 1;
            haku.siirtyma = "PaavalikkoMenu";
            
            haku.StartCoroutine("GetServeri");

            Debug.Log("Tarkistus");
        }

        else
        {
            u_info2.SetActive(true);
        }
    }
}
