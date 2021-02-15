using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private void Vist()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,10))
        {
            Debug.Log(hit.collider.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vist();
    }
}
