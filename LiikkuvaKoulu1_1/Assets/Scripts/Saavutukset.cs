using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Saavutukset : MonoBehaviour
{
    GetHaku haku;

    private int response;
    private string[] value;
    public int r_id;


    void Start() //Lähetetään käsky hakea ja luoda saavutukset
    {
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        value = new string[0];
        haku.id = 3;
        value[1] = haku.r_id.ToString();
        
        haku.StartCoroutine("LocationHandler");
    }


    public void Paavalikkoon() // Takaisin päävalikkoon nappi
    {
        SceneManager.LoadScene(2);
        Debug.Log("päävalikkoon");
    }

}