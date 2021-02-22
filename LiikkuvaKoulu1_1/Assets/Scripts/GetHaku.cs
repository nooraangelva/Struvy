using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class Luokkatieto
{
    public string[] l_data;
    public int l_id;
}

public class GetHaku : MonoBehaviour
{
    public GameObject saavutukset;
    public GameObject info;

    public string siirtyma;
    public string[] data;
    public int id;
    public int r_id;
    
    void Start()
    { 
        DontDestroyOnLoad(this);// Ei tuhoudu vaikka scene vaihtuu
    }

    IEnumerator LocationHandler()
    {
        yield return new WaitForSeconds(1f);

            //getin rakennus
            Luokkatieto serveri = new Luokkatieto();
            serveri.l_data = data;
            serveri.l_id = id;
            string jsonMessage = JsonUtility.ToJson(serveri);

            // getin lähetys
            using (UnityWebRequest www = UnityWebRequest.Get("http://54.160.118.215/struvy/GetHaku.php?"+ jsonMessage))
            {
                www.SetRequestHeader("Accept", "application/json");
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError) //Haku epäonnistui
                {
                    Debug.Log(www.error);

                }
                else //Haku onnistui
                {
                    Debug.Log("Form upload complete!");
                    
                    if(id == 1)//Kirjautuminen
                    {
                        //www.downloadHandler.text;
                        SceneManager.LoadScene(siirtyma);
                    }
                    else if(id == 3)// Saavutuksien laitto
                    {
                        saavutukset = GameObject.Find("SaavutusValikko");
                        //www.downloadHandler.text;
                        Debug.Log(www.downloadHandler.text);
                    }
                    else if(id == 4) //Top10 laitto
                    {
                        saavutukset = GameObject.Find("TopValikko");
                        //www.downloadHandler.text;
                        Debug.Log(www.downloadHandler.text);
                    }
                }
            }       
    }

    void Update()
    {
        
    }   
}
