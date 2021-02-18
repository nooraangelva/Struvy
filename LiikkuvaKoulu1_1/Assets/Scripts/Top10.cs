using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Top10 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Paavalikko()
    {
        //SceneManager.UnloadSceneAsync("Top10Menu");
        SceneManager.LoadScene(2);
        Debug.Log("Päävalikkoon");
    }
    void Update()
    {
        
    }
}
