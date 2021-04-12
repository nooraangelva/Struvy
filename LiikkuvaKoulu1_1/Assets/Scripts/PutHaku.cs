
// Luodaan aloitusvalikossa, eikä tuhota
// Toiminta: Lähettää tietokantaan dataa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class LuokkatietoPut
{
    public string[] l_data;
    public int l_id;
}

public class PutHaku : MonoBehaviour
{
    public GameObject info;

    public string siirtyma;
    public string[] data;
    public int id;
    public string vastaus;


    void Start()
    { 
        DontDestroyOnLoad(this);// Ei tuhoudu vaikka scene vaihtuu
    }

    IEnumerator PutServeri()// Datan lähetys, rakennus ja visualisointi "Pomo"
    {
        yield return new WaitForSeconds(1f);

            //putin rakennus
            LuokkatietoPut serveri = new LuokkatietoPut();
            serveri.l_data = data;
            serveri.l_id = id;
            string jsonMessage = JsonUtility.ToJson(serveri);

            //putin lähetys
            using (UnityWebRequest www = UnityWebRequest.Put("http://52.91.146.156/LiikkuvaKoulu_Struvy/Put.php", jsonMessage))
            {
                www.SetRequestHeader("Accept", "application/json");
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError) //Ei onnistunut
                {
                    Debug.Log(www.error);

                }
                else //Onnistui
                {
                    
                    if(id == 2) //Käyttäjä luotu
                    {
                        SceneManager.LoadScene(siirtyma);
                    }
                    switch (id)
                    {
                        case 2: //tilin luonti
                            SceneManager.LoadScene(siirtyma);
                            break;

                        case 3: // kysymyksen merkkaus kysytyksi
                            Debug.Log(www.downloadHandler.text);
                            break;

                        case 4: // lisa pisteiden laitto
                            Debug.Log(www.downloadHandler.text);
                            break;
                    }
                }
            }    

    }
    
    void Update()
    {
        
    }   
}
