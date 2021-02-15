using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Items
{
    none,
    coin,
    mushroom,
    //fireFlower,
    //star,
}

public class MarioItems : MonoBehaviour
{
    //MarioItems()
    //{

    //}

    //~MarioItems()
    //{

    //}
    [SerializeField]Items items;
    //[SerializeField] 
    CoinUI coinUI;
    Player playerScript;
    public bool _getItem { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        GameObject mPlayer = GameObject.FindWithTag("Player");
        GameObject mCoinUI = GameObject.FindWithTag("GameUIController");
        if (mPlayer != null) playerScript = mPlayer.GetComponent<Player>();
        if (mCoinUI != null) coinUI = mCoinUI.GetComponent<CoinUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (items)
            {
                case Items.mushroom:
                    Mushroom();
                    this.items = Items.none;
                    this.gameObject.SetActive(false);
                    break;
                case Items.coin:
                    Coin();
                    this.gameObject.SetActive(false);
                    break;
            }
        }
    }

    private void Mushroom()
    {
        Debug.Log("マリオが大きくなったよ");
        playerScript.status = PlayerStatus.big;
        _getItem = true;
    }
    
    private void Coin()
    {
        coinUI.coinNumber++;
        _getItem = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
