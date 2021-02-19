using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif
/*
{
    public static float data_1;
    public static float data_2;
    public static int id;
}
/*
public static class GetHaku
{

    public string data_1;
    public string data_2;
    public int id;

    public static void Init(string kt, string ss, int kirjautuminen)
    {
        Luokkatieto.data_1 = kt;
        Luokkatieto.data_2 = ss;
        Luokkatieto.id = kirjautuminen;
    }*/
    // Start is called before the first frame update
public static class GetHaku
{
    static int GetLahetys(string u_data_1, string u_data_2, int u_id)
    {
            //postin rakennus ja lähetys
            
            /*data_1 = u_data_1;
            data_2 = u_data_2;
            id = u_id;*/
            string jsonMessage = JsonUtility.ToJson(u_data_1);


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
