using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Saavutukset : MonoBehaviour
{

    void Start() //Lähetetään käsky hakea ja luoda saavutukset
    {
 
    }


    public void Paavalikkoon() // Takaisin päävalikkoon nappi
    {
        SceneManager.LoadScene(2);
        Debug.Log("päävalikkoon");
    }

}