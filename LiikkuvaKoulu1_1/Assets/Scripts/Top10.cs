//Scene: Top10Menu
// Toiminta: Asettaa pelaajat paremmuusjärjestykseen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Top10 : MonoBehaviour
{
    GetHaku haku;
    GameObject top10Paneeli;
    GameObject topStreak;

    Text pelaajanNimi;
    Text pelaajanStreak;
    Text nappi;

    public string[] value;
    int x;

    void Start() //Lähetetään käsky hakea ja luoda Top10 jutut
    {
        /*haku = GameObject.Find("Lahettaja").GetComponent<GetHaku>();

        value[0] = haku.r_id.ToString();
        haku.data = value;
        haku.id = 3;
        haku.StartCoroutine("GetServeri");

        value[0] = haku.r_id.ToString();
        haku.data = value;
        haku.id = 4;
        haku.StartCoroutine("GetServeri");*/

        top10Paneeli = GameObject.Find("Top10paneeli");
        pelaajanNimi = GameObject.Find("PelaajanNimi").GetComponent<Text>();

        topStreak = GameObject.Find("TopStreak");
        pelaajanStreak = GameObject.Find("PelaajanStreak").GetComponent<Text>();

        nappi = GameObject.Find("VaihtoNappi").GetComponent<Text>();

        for(x = 0; x < 11; x++){

            if (x == 0)
            {
                //pelaajanNimi.text = x+1+".  "+haku.matkaTop[x].nimi+"  "+haku.matkaTop[x].km+"km";
                //pelaajanStreak.text = x+1+".  "+haku.streakTop[x].nimi+"  "+haku.streakTop[x].km+"km";

                //testi
                pelaajanNimi.text = ""+x+"km";
                pelaajanStreak.text = ""+x;
            }
            else{

                GameObject tekstiMatka = new GameObject("TextKM"+x);
                tekstiMatka.transform.parent = top10Paneeli.transform;
                RectTransform transKM = tekstiMatka.AddComponent<RectTransform>();
                transKM.anchoredPosition = new Vector2(0, (350-(x*80)));//sijainti - arvot laskuna
                transKM.sizeDelta = new Vector2 (400, 137);
                transKM.localScale = new Vector3(1f,1f,1f);
                Text textKM = tekstiMatka.AddComponent<Text>();
                //textKM.text = x+1+".  "+haku.matkaTop[x].nimi+"  "+haku.matkaTop[x].km+"km";
                //testi
                textKM.text = ""+x+"km";
                textKM.fontSize = 40;
                textKM.color = Color.black;
                textKM.alignment = TextAnchor.MiddleCenter;
                textKM.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

                GameObject tekstiS = new GameObject("TextS"+x);
                tekstiS.transform.parent = topStreak.transform;
                RectTransform transS = tekstiS.AddComponent<RectTransform>();
                transS.anchoredPosition = new Vector2(0,371);//sijainti - arvot laskuna
                transS.sizeDelta = new Vector2 (167, 137);
                transS.localScale = new Vector3(1f,1f,1f);
                Text textS = tekstiS.AddComponent<Text>();
                //textS.text = x+1+".  "+haku.matkaTop[x].nimi+"  "+haku.matkaTop[x].streak;
                //testi
                textS.text = ""+x;
                textS.fontSize = 40;
                textS.color = Color.black;
                textS.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            }
        }

        topStreak.SetActive(false);
    }

    public void Paavalikko() //Takaisin päävalikkoon nappi
    {
        SceneManager.LoadScene(2);
        Debug.Log("Päävalikkoon");
    }

    public void CanvasVaihto() // Vaihtaa Top10 ja streakin välillä
    {
        if(top10Paneeli.activeSelf == true){

            topStreak.SetActive(true);
            top10Paneeli.SetActive(false);
            nappi.text = "Matka";
        }
        else{

            topStreak.SetActive(false);
            top10Paneeli.SetActive(true);
            nappi.text = "Streak";
        }
    }

    void Update()
    {

    }
}
