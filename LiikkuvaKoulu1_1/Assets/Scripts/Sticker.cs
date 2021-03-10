using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sticker : MonoBehaviour
{
    GetHaku haku;

    private string[] value;
    public int r_id;
    public int matka, k_pisteet;

    void Start()
    {
        //haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        //value = new string[1];
        //HakunaMatata();
        matka = 500;
        
    }


    public void HakunaMatata()
    {
        value[0] = r_id.ToString();
        haku.data = value;
        haku.id = 2;
        
        haku.StartCoroutine("LocationHandler");
        matka = 10;
    }

    void Update()
    {

    }
}
