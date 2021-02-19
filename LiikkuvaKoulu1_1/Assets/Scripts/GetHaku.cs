using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif
public class Luokkatieto
{
    public float data_1;
    public float data_2;
    public int id;
}

public class GetHaku : MonoBehaviour
{

    public float data_1;
    public float data_2;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        

        //StartCoroutine("GetLahetys");
        
    
    }
    IEnumerator GetLahetys()
    {
            //postin rakennus ja lähetys
            Luokkatieto serveri = new Luokkatieto();
            serveri.data_1 = data_1;
            serveri.data_2 = data_2;
            serveri.id = id;
            string jsonMessage = JsonUtility.ToJson(serveri);


            using (UnityWebRequest www = UnityWebRequest.Put("http://54.160.118.215/tiedonhallinta/TallennaGPS_data.php", jsonMessage))
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
                }
            }    
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
