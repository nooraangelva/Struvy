//Scene: UnescoInfo

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnescoNappi : MonoBehaviour
{
    GameObject unescoInfo;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Poistu() //Poistuu infosta
    {
        unescoInfo = GameObject.Find("UnescoInfo");
        unescoInfo.SetActive(false);
        Debug.Log("poistu");
        Time.timeScale = 1;//unpause
        
    }
}
