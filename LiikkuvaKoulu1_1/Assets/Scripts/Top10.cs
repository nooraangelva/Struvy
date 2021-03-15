using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Top10 : MonoBehaviour
{
    GetHaku haku;

    //private int response;
    private string[] value;

    void Start() //Lähetetään käsky hakea ja luoda Top10 jutut
    {
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        value[0] = haku.r_id.ToString();
        haku.data = value;
        haku.id = 4;
        
        haku.StartCoroutine("GetServeri");
    }

    public void Paavalikko() //Takaisin päävalikkoon nappi
    {
        SceneManager.LoadScene(2);
        Debug.Log("Päävalikkoon");
    }

    void Update()
    {
        //laatikoiden taytto, ja streak nakyma
    }
}
