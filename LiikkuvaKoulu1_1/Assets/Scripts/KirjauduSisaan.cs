using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class KirjauduSisaan : MonoBehaviour
{
    
    GameObject info;
    Text kt;
    Text ss;
    private int response;
    GetHaku haku;
    private string[] value;

    // Start is called before the first frame update
    void Start()
    {
        //info = GameObject.Find("KirjauduVirhe");
        kt = GameObject.Find("Kayttajatunnus").GetComponent<Text>();
        ss = GameObject.Find("Salasana").GetComponent<Text>();
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        value = new string[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kirjaudu()
    {

        value[0] = (string)kt.text;
        value[1] = (string)ss.text;
        haku.data = value;
        haku.id = 1;
        haku.siirtyma = "Paavalikko";
        haku.info = GameObject.Find("KirjauduVirhe");
        haku.StartCoroutine("LocationHandler");

        
       /* if(response == 0)
        {

            SceneManager.LoadScene("Paavalikko");
        }
        else
        {
            info.SetActive(true);
        }*/
    }
}
