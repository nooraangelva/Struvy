using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnescoNappi : MonoBehaviour
{
    GameObject unescoInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Poistu()
    {
        unescoInfo = GameObject.Find("UnescoInfo");
        unescoInfo.SetActive(false);
        Debug.Log("poistu");
        Time.timeScale = 1;//unpause
        
    }
}
