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
        SceneManager.LoadScene("SaavutusMenu");
        Debug.Log("SaavutusMenu");
    }
    public void Top10()
    {
        SceneManager.LoadScene("Top10Menu");
        Debug.Log("10");
    }
    public void LopetaPeli()
    {
        Application.Quit();
        Debug.Log("kukkuu");
    }
}
