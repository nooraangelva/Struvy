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
    public GameObject info;
    public string siirtyma;
    public string[] data;
    public int id;
   

    // Start is called before the first frame update
    void Start()
    { 
        DontDestroyOnLoad(this);
    }

    IEnumerator LocationHandler()
    {
        yield return new WaitForSeconds(1f);

            //getin rakennus ja lähetys
            Luokkatieto serveri = new Luokkatieto();
            serveri.l_data = data;
            serveri.l_id = id;
            string jsonMessage = JsonUtility.ToJson(serveri);


            using (UnityWebRequest www = UnityWebRequest.Get("http://54.160.118.215/struvy/GetHaku.php?"+ jsonMessage))
            {
                www.SetRequestHeader("Accept", "application/json");
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);

                }
                else
                {
                    Debug.Log("Form upload complete!");
                    SceneManager.LoadScene(siirtyma);
                }
            }    
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }   
}
