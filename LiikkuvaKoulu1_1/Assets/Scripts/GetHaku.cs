// Scriptin toiminta: Tietokanta Gethaku ja datan rakennus luettavaksi
// Luodaan aloitusvalikossa eikä tuhota

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif
using System;


public class Luokkatieto
{
    public string turvakoodi;
    public string[] l_data;
    public int l_id;
}

[Serializable]
public class GameResponse
{
    public string matka;
    public string streak;
}

[Serializable]
public class TopMResponse
{
    public string nimi;
    public string km;
}

[Serializable]
public class TopSResponse
{
    public string nimi;
    public string streak;
}

[Serializable]
public class QuestionResponse
{
    public string id;
    public string kysymys;
    public string vastaukset;
    public string oikein;
}

[Serializable]
public class TunnusResponse
{
    public string r_id;
}

public class GetHaku : MonoBehaviour
{
    public GameObject saavutukset;
    public GameObject info;

    public GameResponse vastausMatka;
    public QuestionResponse vastausKysymys;
    public TunnusResponse vastausTunnus;
    public TopMResponse matkaTop;
    public TopSResponse streakTop;

    public string siirtyma;
    public string[] data;
    public int id;
    public int r_id;
    public string vastaus;
    
    void Start()
    { 
        DontDestroyOnLoad(this);// Ei tuhoudu vaikka scene vaihtuu
    }

    IEnumerator GetServeri()//get haku serverille (main boss kaikille geteille)
    {
        yield return new WaitForSeconds(1f);

            //getin rakennus
            Luokkatieto serveri = new Luokkatieto();
            serveri.turvakoodi = "Saani_159";
            serveri.l_data = data;
            serveri.l_id = id;
            string jsonMessage = JsonUtility.ToJson(serveri);

            Debug.Log("http://52.91.146.156/LiikkuvaKoulu_Struvy/Get.php,"+ jsonMessage);

            // getin lähetys
            using (UnityWebRequest www = UnityWebRequest.Put("http://52.91.146.156/LiikkuvaKoulu_Struvy/Get.php", jsonMessage))
            {
                www.SetRequestHeader("Accept", "application/json");
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError) //Haku epäonnistui
                {
                    Debug.Log(www.error);

                }
                else //Haku onnistui
                {
                    Debug.Log("Haku complete!");
                    
                    switch (id)
                    {
                        case 1: //Kirjautuminen
                            Debug.Log(www.downloadHandler.text);
                            vastausTunnus = JsonUtility.FromJson<TunnusResponse>(www.downloadHandler.text);
                            Debug.Log(vastausTunnus.r_id);
                            r_id = int.Parse(vastausTunnus.r_id);
                            SceneManager.LoadScene(siirtyma);
                            break;

                        case 3: // Top10 streak Laitto
                            Debug.Log(www.downloadHandler.text);
                            saavutukset = GameObject.Find("TopValikko");
                            streakTop = JsonUtility.FromJson<TopSResponse>(www.downloadHandler.text);
                            Debug.Log(www.downloadHandler.text);
                            break;

                        case 4: // Top10 matka
                            Debug.Log(www.downloadHandler.text);
                            saavutukset = GameObject.Find("TopValikko");
                            matkaTop = JsonUtility.FromJson<TopMResponse>(www.downloadHandler.text);
                            Debug.Log(www.downloadHandler.text);
                            break;

                        case 2: //Matka Haku
                            Debug.Log(www.downloadHandler.text);
                            vastausMatka = JsonUtility.FromJson<GameResponse>(www.downloadHandler.text);
                            break;

                        case 5: //kysymys haku
                            Debug.Log(www.downloadHandler.text);
                            vastausKysymys = JsonUtility.FromJson<QuestionResponse>(www.downloadHandler.text);
                            break;

                    }
               
                }
            }       
    }

    void Update()
    {
        
    }   
}
