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
    public int matka;

    void Start()//Liikutun matkan haun alustus
    {/*
        value[0] = haku.r_id.ToString();
        haku.data = value;
        haku.id = 2;
        
        haku.StartCoroutine("GetServeri");*/
        matka = 5;
        
    }

    void Update()
    {

    }
}
