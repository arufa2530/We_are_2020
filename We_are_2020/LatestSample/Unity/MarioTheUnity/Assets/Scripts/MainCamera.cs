using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]GameObject player;
    //[SerializeField]GameObject rightObj;
    //[SerializeField]GameObject leftObj;
    Vector2 startPos;
    public bool _isUnderground; //{ get; set; }
    //public bool rightSide;
    //public bool leftSide;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    void Main()
    {
        transform.position = new Vector3(player.transform.position.x, startPos.y,transform.position.z);

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= 220)
        {
            transform.position = new Vector3(220, transform.position.y, transform.position.z);
        }
    }

    private void Sub()
    {
        transform.position = new Vector3(0, -100, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        if (!_isUnderground) Main();
        else if (_isUnderground) Sub();
    }
}
