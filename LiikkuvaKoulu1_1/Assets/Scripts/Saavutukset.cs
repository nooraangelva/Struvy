using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Saavutukset : MonoBehaviour
{
    private int response;
    GetHaku haku;
    private string[] value;


    void Start()
    {
        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        value = new string[1];
    }


    public void Paavalikkoon()
    {
        SceneManager.LoadScene(2);
        Debug.Log("päävalikkoon");
    }

}