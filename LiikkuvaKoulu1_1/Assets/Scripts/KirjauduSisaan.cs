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

    public int response;
    public int r_id;


    void Start() //Määritellään componentit
    {
        kt = GameObject.Find("Kayttajatunnus").GetComponent<Text>();
        ss = GameObject.Find("Salasana").GetComponent<Text>();
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        info = GameObject.Find("KirjauduVirhe");
        info.SetActive(false);

    }

    public void Kirjaudu() //Lähettää käskyn tarkistaa tunnukset
    {
        string[] value = {kt.text.ToString(), ss.text.ToString()};
        //value[0] = kt.text.ToString();
        //value[1] = ss.text.ToString();


        haku.data = value;
        haku.id = 1;
        haku.siirtyma = "PaavalikkoMenu";
        
        haku.StartCoroutine("GetServeri");
        StartCoroutine(Odotus());

        Debug.Log("Tarkistus");

        
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

        if(!haku.vastausTunnus.r_id.Contains(""))
        {
            Debug.Log("Paavalikkoon");
        }
        else
        {
            info.SetActive(true);
        }
    }
    
}
