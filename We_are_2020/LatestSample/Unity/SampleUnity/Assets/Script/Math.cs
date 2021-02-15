using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math : MonoBehaviour
{
    //private float _cost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void VariousMath()
    {
        if(Input.GetKey(KeyCode.R))
        {
            //_cost = Mathf.Sin(1);
            transform.position = new Vector3(0, Mathf.Sin(Time.time * 2) * 1.5f , 0);
        }
        else if(Input.GetKey(KeyCode.T))
        {
            transform.position = new Vector3(0, Mathf.Cos(Time.time * 2) * 1.5f, 0);
        }
        else if(Input.GetKey(KeyCode.Y))
        {
            transform.position = new Vector3(0, Mathf.Tan(Time.time * 2) * 1.5f, 0);
        }
        else if(Input.GetKey(KeyCode.U))
        {

        }
        else if(Input.GetKey(KeyCode.T))
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        VariousMath();
    }
}
