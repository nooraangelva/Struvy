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

    void Start()//Liikutun matkan haun alustus
    {
        matka = 500;
        
    }


    /*public void MatkanHaku()//matkan haku
    {
        value[0] = r_id.ToString();
        haku.data = value;
        haku.id = 2;
        
        haku.StartCoroutine("GetServeri");
        matka = 10;
    }*/

    void Update()
    {

    }
}
