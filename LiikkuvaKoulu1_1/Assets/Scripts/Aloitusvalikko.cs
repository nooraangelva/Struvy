using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Aloitusvalikko : MonoBehaviour
{
    public void KirjauduSisaan()
    {
        SceneManager.LoadScene("KirjauduMenu");
        Debug.Log("Kirjaudu");
    }

    public void LuoTunnukset()
    {
        SceneManager.LoadScene("TunnusMenu");
        Debug.Log("TunnusMenu");
    }
}
