using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWorld : MonoBehaviour
{
    GameObject mPlayer;
    [SerializeField]Camera mCamera;

    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == mPlayer)
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                mPlayer.transform.position = new Vector2(-8.3f,-90f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
