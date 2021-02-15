using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosDie : MonoBehaviour
{
    [SerializeField]GameObject player;
    Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            playerScript._disJump = 2000;
            playerScript.status = PlayerStatus.none;
            playerScript._isJump = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(player.transform.position.x, transform.position.y);
    }
}
