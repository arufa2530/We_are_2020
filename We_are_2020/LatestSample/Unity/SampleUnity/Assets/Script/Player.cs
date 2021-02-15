using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField]GameObject Summon;
    GameObject Ball;
    // Start is called before the first frame update
    void Start()
    {
        Ball = GameObject.Find("Ball");
    }

    private void PlayerCont()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("前に進んだよ");
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("後ろに下がったよ");
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("左に動いたよ");
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("右に動いたよ");
        }
    }

    private void FindObjct()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Vector3 Whereabouts = Summon.transform.position;
            GameObject CopBall = Object.Instantiate(Ball) as GameObject;
            CopBall.transform.Translate(Whereabouts);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCont();
        FindObjct();
    }
}
