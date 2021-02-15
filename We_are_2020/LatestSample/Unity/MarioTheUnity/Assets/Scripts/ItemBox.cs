using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ItemList
{
    none,
    coin,
    mushroom,
}
public class ItemBox : MonoBehaviour
{
    [SerializeField] GameObject[] itemListBox;
    GameObject Item;

    Vector2 Point;
    bool _isOp;
    bool _isAct;
    bool _isHit;

    MarioItems itemScript;
    SpriteRenderer spr;
    [SerializeField] BoxCollider2D[] m_Col;
    CapsuleCollider2D playerCol;
    [SerializeField] Sprite off;
    [SerializeField]ItemList itemList;

    // Start is called before the first frame update
    void Start()
    {
        switch(itemList)
        {
            case ItemList.coin:
                Item = itemListBox[0];
                break;
            case ItemList.mushroom:
                Item = itemListBox[1];
                break;
        }
        GameObject mPlayer = GameObject.FindWithTag("Player");
        if (mPlayer != null) playerCol = mPlayer.GetComponent<CapsuleCollider2D>();
        spr = GetComponent<SpriteRenderer>();
        m_Col = GetComponentsInChildren<BoxCollider2D>();
        Item = Instantiate(Item);
        itemScript = Item.GetComponent<MarioItems>();
        itemScript._getItem = false;
        Item.transform.position = transform.position;
        Item.transform.SetParent(gameObject.transform);
        Item.gameObject.SetActive(false);
        _isAct = true;
        _isOp = false;
        _isHit = false;
        Point = (Vector2)transform.position + new Vector2(0.0f, 1.2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_Col[1].IsTouching(playerCol) &&
            collision.gameObject.CompareTag("Player"))
        {
            Item.gameObject.SetActive(true);
            _isOp = true;
            StartCoroutine(WaitSwitch());
            //Debug.Log("ねっむ");
        }
    }

    private void PopItem()
    {
        if(_isOp && _isAct && !itemScript._getItem)
        {
            Item.transform.position =
                Vector2.Lerp(Item.transform.position, Point, 0.35f);
            spr.sprite = off;
            //_isHit = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PopItem();
        //Debug.Log(_isAct);
        Debug.Log(itemScript._getItem);
    }

    private IEnumerator WaitSwitch()
    {
        yield return new WaitForSeconds(1.0f);
        _isAct = false;
    }
}
