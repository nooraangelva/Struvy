using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Top10 : MonoBehaviour
{
    GetHaku haku;

    private int response;
    private string[] value;

    void Start() //Lähetetään käsky hakea ja luoda Top10 jutut
    {
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        value = new string[0];
        haku.id = 4;
        
        haku.StartCoroutine("LocationHandler");
    }

    public void Paavalikko() //Takaisin päävalikkoon nappi
    {
        SceneManager.LoadScene(2);
        Debug.Log("Päävalikkoon");
    }
    void Update()
    {
        
    }
}
