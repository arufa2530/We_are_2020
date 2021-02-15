using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void PlayerControl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("前に進んだよ");
            transform.position += transform.forward * 3 * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("後ろに下がったよ");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("左に動いたよ");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("右に動いたよ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }
}
