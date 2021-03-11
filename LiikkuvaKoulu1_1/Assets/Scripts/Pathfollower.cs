using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfollower : MonoBehaviour
{
    Node[] PathNode;
    public GameObject sticker;

    Sticker koodi;
    QuizManager kyssari;
    float Timer;
    static Vector3 CurrentPositionHolder;
    int CurrentNode;
    int x;
    int y;
    int z;
    int[] pisteet = {10, 76, 171, 247, 297, 382, 458, 538, 614, 644, 754, 830, 880, 980};

    void Start()
    {
        kyssari = GameObject.Find("QuizManager").GetComponent<QuizManager>();
        sticker = GameObject.Find("Sticker");
        koodi = sticker.GetComponent<Sticker>();
        PathNode = GetComponentsInChildren<Node>();
        CheckNode();
        x = 0;
        y = 2;// haettu tietokannasta käydyt pisteet - kesken

        for(z = 0; z < y; z++)
        {
           // pisteet.RemoveAt(y);
        }
        
    }

    void CheckNode()
    {
        Timer = 0;
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
    }

    void Update()
    {
        if (x < koodi.matka)
        {
            if(IndexOf(pisteet, x))
            {
                kyssari.generateQuestion();
                Time.timescale = 0;
            }

            //Timer += Time.deltaTime * 0.00771f;
            Timer += 0.5f;
            if(sticker.transform.position != CurrentPositionHolder)
            {
                sticker.transform.position = Vector3.Lerp(sticker.transform.position, CurrentPositionHolder, Timer);
                Debug.Log(Timer+"="+Time.deltaTime+"*"+0.00771f);
            }
            else
            {
                if (CurrentNode < PathNode.Length -1)
                {
                        CurrentNode++;
                        CheckNode();
                        Debug.Log("kakkaa3");
                }
            }
        }
        x++;
    }
}
