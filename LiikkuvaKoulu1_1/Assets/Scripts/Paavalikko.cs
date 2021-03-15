using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Paavalikko : MonoBehaviour
{
    
    public void Peliin()//nappi, lataa peli scene 
    {
        SceneManager.LoadScene(6);
        Debug.Log("Avataan pelinakyma");    
    }

    /*public void Saavutukset()//nappi, lataa 
    {
        SceneManager.LoadScene(3);
        Debug.Log("SaavutusMenu");
    }*/

    public void Top10()//nappi, lataa top-listat scene
    {
        //SceneManager.UnloadSceneAsync("PaavalikkoMenu");
        SceneManager.LoadScene(4);
        Debug.Log("10");
    }

    public void LopetaPeli()//nappi, lopeta peli
    {
        Application.Quit();
        Debug.Log("kukkuu");
    }
}
