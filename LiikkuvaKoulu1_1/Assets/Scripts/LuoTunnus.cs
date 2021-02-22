using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LuoTunnus : MonoBehaviour
{
    GameObject info;
    GameObject u_info;
    Text u_kt;
    Text u_ss;
    Text u_ss2;
    private int response;
    PutHaku p_haku;
    private string[] value;
    // Start is called before the first frame update
    
    void Start()
    {
        //u_info = GameObject.Find("TunnusVirhe").GetComponent<Text>();
        u_kt = GameObject.Find("Kayttajatunnus").GetComponent<Text>();
        u_ss = GameObject.Find("Salasana").GetComponent<Text>();
        u_ss2 = GameObject.Find("VarmistaSalasana").GetComponent<Text>();
        p_haku = GameObject.Find("Lahettaja").GetComponent<PutHaku>();
        info = GameObject.Find("Lahettaja");
        u_info = GameObject.Find("TunnusVirhe");
        value = new string[2];
    }

    // Update is called once per frame
    public void TunnusLuo()
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
        /*if(response == 0)
        {

            SceneManager.LoadScene("Paavalikko");
        }
        else
        {
            u_info.SetActive(true);
        }*/
    }
       void Update()
       {

       }
}
