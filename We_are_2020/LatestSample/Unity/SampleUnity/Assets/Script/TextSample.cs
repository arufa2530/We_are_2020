using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSample : MonoBehaviour
{
    [SerializeField]private Text seneText;
    private List<string> texts;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void TextSentence()
    {
        texts = new List<string>()
        {
            "初めまして",
            "私はこの世界で唯一の蟹",
            "君には私の分身として",
            "この世界を旅をしてもらいたい",
            "まぁ、君はもう死んでしまっているから",
            "拒否権はないんだけどね",
            "ま、存分に楽しんできなよ",
            "この世界を旅するだけの力も与えてあげるからさ",
            "では、また会える日を楽しみにしているよ",
        };
    }

    private void OutText()
    {
        seneText.text = texts[i];

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(texts[i]);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TextSentence();
        OutText();
    }
}
