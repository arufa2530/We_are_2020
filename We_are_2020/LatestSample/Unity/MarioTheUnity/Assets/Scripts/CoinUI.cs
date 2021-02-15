using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField]private Text CoinText;

    public int coinNumber { get; set; }
    int marioLife;

    // Start is called before the first frame update
    void Start()
    {
        coinNumber = 0;
        marioLife = 1;
    }

    void CoinGet()
    {
        if (Input.GetKeyDown(KeyCode.K)) { coinNumber++; }
        CoinText.text = string.Format("× {0:00}",coinNumber);
        if(coinNumber >= 100)
        {
            coinNumber = 0;
            marioLife++;
            Debug.Log(marioLife);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CoinGet();
    }
}
