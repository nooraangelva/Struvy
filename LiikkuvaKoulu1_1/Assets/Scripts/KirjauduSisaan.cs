using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class KirjauduSisaan : MonoBehaviour
{
    Text info;
    Text kt;
    Text ss;
    private int response;

    // Start is called before the first frame update
    void Start()
    {
        info = GameObject.Find("KirjauduVirhe").GetComponent<Text>();
        kt = GameObject.Find("Kayttajatunnus").GetComponent<Text>();
        ss = GameObject.Find("Salasana").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kirjaudu()
    {
        response = GetHaku.GetLahetys(kt.text,ss.text,1);
        /*lahetys.data_1 = kt.text;
        lahetys.data_2 = ss.text;
        lahetys.id = 1;*/
        //response = StartCoroutine("GetLahetys");
        if(response == 200)
        {
            SceneManager.LoadScene("Paavalikko");
        }
        else
        {
            info.SetActive(true);
        }
    }
}
