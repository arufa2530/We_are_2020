using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void UiText()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UiText();
        if(Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("GameMain");
        }
    }
}
