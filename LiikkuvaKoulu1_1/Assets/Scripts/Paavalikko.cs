//Scene: Paavalikko

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Paavalikko : MonoBehaviour
{
    
    public void Peliin()//nappi, lataa peli scene 
    {
        SceneManager.LoadScene("Pelinakyma");
        Debug.Log("Avataan pelinakyma");    
    }

    public void Info()//nappi, lataa 
    {
        SceneManager.LoadScene("Info");
        Debug.Log("info");
    }

    public void Top10()//nappi, lataa top-listat scene
    {
        //SceneManager.UnloadSceneAsync("PaavalikkoMenu");
        SceneManager.LoadScene("top10Menu");
        Debug.Log("10");
    }

    public void LopetaPeli()//nappi, lopeta peli
    {
        Application.Quit();
        Debug.Log("kukkuu");
    }
}
