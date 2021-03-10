using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfollower : MonoBehaviour
{
    Node[] PathNode;
    public GameObject sticker;

    Sticker koodi;
    float Timer;
    static Vector3 CurrentPositionHolder;
    int CurrentNode;
    int x;

    void Start()
    {
        sticker = GameObject.Find("Sticker");
        koodi = sticker.GetComponent<Sticker>();
        PathNode = GetComponentsInChildren<Node>();
        CheckNode();
        x = 0;
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
