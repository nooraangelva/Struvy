using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sticker : MonoBehaviour
{
    GetHaku haku;

    private string[] value;
    public int r_id;
    private int matka;

    void Start()
    {

        haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();
        value = new string[1];
        HakunaMatata();
        Transform
    }

    public void HakunaMatata()
    {
        value[0] = r_id.ToString();
        haku.data = value;
        haku.id = 2;
        
        haku.StartCoroutine("LocationHandler");
        matka = 10;
    }

    /* protected void KohdettaPain(Vector3 to)
    {
     Quaternion _lookRotation = Quaternion.LookRotation((to - transform.position).normalized);
     transform.position += _lookRotation * Vector3.forward * Time.deltaTime * move_speed;
    }

    protected IEnumerator Liikkuminen()
     {
         for ( ;; )
         {
             if (destination == new Vector3(-1f,-1f,-1f)) break; // end of path
             moveTowards(destination);
             yield return 0;
         }
     }
     protected IEnumerator Reitti()
     {
         for ( ;; )
         {
             destination = ... // Next Point
             if (destination == new Vector3(-1f,-1f,-1f)) break; // end of path
             
             while (!closeEnough()) yield return 0;
         }
     }*/

    void Update()
    {
        
    }
}
