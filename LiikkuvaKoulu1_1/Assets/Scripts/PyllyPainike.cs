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
        SceneManager.LoadScene(2);
        Debug.Log("Päävalikkoon");
    }
}
