//Scene: Pelinakyma

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PyllyPainike : MonoBehaviour
{
 
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Paavalikko() //Takaisin päävalikkoon nappi
    {
        SceneManager.LoadScene("PaavalikkoMenu");
        Debug.Log("Päävalikkoon");
    }

    public void Aloitusmenu() //Takaisin päävalikkoon nappi
    {
        Debug.Log("Testaus");
        SceneManager.LoadScene("AloitusMenu");
        Debug.Log("Aloitusmenuun");
    }
}
