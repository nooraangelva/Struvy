using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Saavutukset : MonoBehaviour
{
    GetHaku haku;

    private int response;
    public string[] value;
    public int r_id;


    void Start() //Lähetetään käsky hakea ja luoda saavutukset
    {
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();

        haku.id = 3;
        value[0] = haku.r_id.ToString();
        haku.StartCoroutine("LocationHandler");

        haku.id = 2;
        value[0] = haku.r_id.ToString();
        haku.StartCoroutine("LocationHandler");
    }


    public void Paavalikkoon() // Takaisin päävalikkoon nappi
    {
        SceneManager.LoadScene(2);
        Debug.Log("päävalikkoon");
    }

}