using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonScript : MonoBehaviour
{
    GameManager manager;
    Player1Script p1Script;

    public bool isLeft;
    public bool isUp;
    public bool isRight;
    public bool isDown;

    bool moveL = false;


    void Start()
    {

        manager = GameObject.Find("MainController").GetComponent<GameManager>();
        p1Script = GameObject.Find("Bambang").GetComponent<Player1Script>();

    }

    void Update()
    {
        if (moveL && !manager.chat)
        {
            p1Script.gameObject.transform.position = new Vector3(p1Script.gameObject.transform.position.x + (-8f * Time.deltaTime), p1Script.gameObject.transform.position.y, p1Script.gameObject.transform.position.z);
        }
    }

    public void OnMouseDown()
    {
        p1Script.OnMoveLeft(true);
        moveL = true;
    }

    public void OnMouseUp()
    {
        p1Script.OnMoveLeft(false);
        moveL = false;
    }

}
