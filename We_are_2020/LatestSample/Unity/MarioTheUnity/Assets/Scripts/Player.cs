using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum PlayerStatus
{
    none = -1, 
    normal,
    big,
}

public class Player : MonoBehaviour
{
    //
    Rigidbody2D rigi2d;
    Animator anim;
    SpriteRenderer spr;
    [SerializeField] private Sprite disSprite;
    [SerializeField] float _accelerationJump = 850f;
    //[SerializeField] float gravity;
    //[SerializeField] float jumpHeight;
    float _maxSpeed = 2f;
    float _moveWalk = 30f;
    float _muki;
    float _jumpPos = 0.0f;
    public float _disJump { get; set; }
    bool _jumpSuppression;
    bool _isDis;
    public bool _isJump { get; set; }
    public PlayerStatus status;
    private new Collider2D colr2d;
    // Start is called before the first frame update
    void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        colr2d = GetComponent<Collider2D>();
        spr = GetComponent<SpriteRenderer>();
        _isJump = false;
        _isDis = false;
    }

    private void PlayerCon()
    {
        int direction = 0;
        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            direction = -1;
        }
        float moveSpeed = Mathf.Abs(rigi2d.velocity.x);
        if (moveSpeed < _maxSpeed)
        {
            rigi2d.AddForce(transform.right * direction * _moveWalk);
            if (direction == 1) _muki = 0.4f;
            if (direction == -1) _muki = -0.4f;
            if(direction != 0)
            {
                transform.localScale = new Vector2(_muki, transform.localScale.y);
            }
            //transform.localScale = new Vector3(direction, transform.localScale.y);
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            _maxSpeed = 6f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            _maxSpeed = 2.5f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !_jumpSuppression)
        {
            //_accelerationJump = 820f;//Time.time;
            JumpPlayer(_accelerationJump);
        }
        if(status == PlayerStatus.big)
        {
            BigMario();
        }
    }

    public void JumpPlayer(float _jumpForce)
    {
        rigi2d.AddForce(transform.up * _jumpForce);
        //_jumpSuppression = true;
    }

    private void BigMario()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grid" ||
            collision.gameObject.tag == "Wall")
        {
            _jumpSuppression = false;
        }
        //_jumpSuppression = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grid" ||
            collision.gameObject.tag == "Wall")
        {
            _jumpSuppression = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grid" ||
            collision.gameObject.tag == "Wall")
        {
            _jumpSuppression = true;
        }
    }

    private void PlayerEnd()
    {
        if(_isJump && !_isDis)
        {
            spr.sprite = disSprite;
            colr2d.isTrigger = true ;
            //transform.position = new Vector2(transform.position.x,transform.position.y);
            JumpPlayer(_disJump);
            _isDis = true;
            _isJump = false;
        }
        if(_isDis)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        if(transform.position.y <= -20f)
        {
            SceneManager.LoadScene("GameMain");
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(status)
        {
            case PlayerStatus.none:
                PlayerEnd();
                break;
            default:
                PlayerCon();
                _accelerationJump = System.Math.Min(_accelerationJump, 850f);
                _accelerationJump = System.Math.Max(_accelerationJump, 0f);
                break;
        }
    }
}
