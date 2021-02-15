using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    private float _moveSpeed = 2f;
    private float _inversion;
    private bool _isOp;
    private bool _isAct;
    private bool _isWall;
    private SpriteRenderer spr;
    Player playerScript;
    [SerializeField]private BoxCollider2D[] m_Col;
    [SerializeField]private CapsuleCollider2D playerCol;
    [SerializeField]private CompositeCollider2D tilemapCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        GameObject mPlayer = GameObject.FindWithTag("Player");
        GameObject mGrid = GameObject.FindWithTag("Grid");
        if (mPlayer != null) playerScript = mPlayer.GetComponent<Player>();
        if (mPlayer != null) playerCol = mPlayer.GetComponent<CapsuleCollider2D>();
        if (mGrid != null) tilemapCollider2D = mGrid.GetComponent<CompositeCollider2D>();
        spr = GetComponent<SpriteRenderer>();
        m_Col = GetComponentsInChildren<BoxCollider2D>();
        _isAct = true;
        _isOp = false;
        _isWall = true;
        _inversion = -Time.deltaTime * _moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_Col[0].IsTouching(playerCol) &&
            collision.gameObject.CompareTag("Player"))
        {
            _isOp = true;
            Debug.Log("クリボーが死んだよ");
        }
        else if(m_Col[1].IsTouching(playerCol) &&
            collision.gameObject.CompareTag("Player") ||
                m_Col[2].IsTouching(playerCol) &&
            collision.gameObject.CompareTag("Player"))
        {
            //_isWall = !_isWall
            if(playerScript.status == PlayerStatus.normal)
            {
                playerScript._disJump = 500;
                playerScript.status = PlayerStatus.none;
                playerScript._isJump = true;
            }
            Debug.Log("マリオに触れたよ");
        }
        if(collision.gameObject.CompareTag("Wall") ||
            collision.gameObject.CompareTag("Enemy"))
        {
            _isWall = !_isWall;
        }
    }

    private void Move()
    {
        if(!_isOp)
        {
            transform.position = new Vector2(transform.position.x + _inversion, transform.position.y);
        }
        _inversion = Time.deltaTime * _moveSpeed;
        if(_isWall)
        {
            _inversion = -Time.deltaTime * _moveSpeed;
        }
        else if(!_isWall)
        {
            _inversion = Time.deltaTime * _moveSpeed;
        }
    }

    private void Out()
    {
        if (_isOp && _isAct)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y);
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Out();
    }
}
