using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Paavalikko : MonoBehaviour
{
    // Start is called before the first frame update
    public void Peliin()
    {
        SceneManager.LoadScene("");
    }

    // Update is called once per frame
    public void Saavutukset()
    {
        SceneManager.LoadScene("");
    }
    public void Top10()
    {
        SceneManager.LoadScene("");
    }
    public void LopetaPeli()
    {
        Application.Quit();
        Debug.Log("kukkuu");
    }
}