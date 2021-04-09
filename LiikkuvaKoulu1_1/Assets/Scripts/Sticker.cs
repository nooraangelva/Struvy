//Scene: Pelinakyma
//Toiminta: Stickerin liikkuminen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sticker : MonoBehaviour
{
    GetHaku haku;
    Text kokonaisMatka;
    Text matkaUnescoon;
    Text streak;

    public int r_id;
    public int matka;
    int x;
    public int unescolle;
    public int streakpisteet;


    int[] pisteet = {10,703,962};

    void Start()//Liikutun matkan haun alustus
    {
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        var value = new string[] {haku.r_id.ToString()}; 
        haku.data = value;
        haku.id = 2;
        
        haku.StartCoroutine("GetServeri");
        kokonaisMatka = GameObject.Find("Kilometrit").GetComponent<Text>();
        matkaUnescoon = GameObject.Find("MUKilometrit").GetComponent<Text>();
        streak = GameObject.Find("Luku").GetComponent<Text>();
        
        //testi
        matka = 20;
        streakpisteet = 2;

        for (x=0; x<3; x++) //Lasketaan lähin Unesco kohta
        {
            if(matka < pisteet[x])
            {
                unescolle=pisteet[x]-matka;
                Debug.Log(unescolle +"="+pisteet[x]+"-"+matka);
                break;
            }
        } 
    }

    void Update()
    {
        //Debug.Log(unescolle);
        kokonaisMatka.text = matka+"/1000 km";
        matkaUnescoon.text = unescolle+"km";
        streak.text = streakpisteet.ToString();
    }
}
