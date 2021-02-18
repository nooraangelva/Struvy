using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Saavutukset : MonoBehaviour
{
    public void Paavalikkoon()
    {
        SceneManager.LoadScene(2);
        Debug.Log("päävalikkoon");
    }

}