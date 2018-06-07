using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2MoveManager : MonoBehaviour {

    //public bool facingRight = true;
    public int playerSpeed = 10;
    public int playerJumpPower2 = 1250;
    public bool onGround2 = false;
    private bool onBox = false;

    public GameObject player1;
    public GameObject player2;

    void Update()
    {
        PlayerMove();
        //Adjust();
    }

    void PlayerMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("space"))
        {
            if(onGround2 == true || onBox == true)
            Jump();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void Jump()
    {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower2);
            onGround2 = false;
        onBox = false;
            
    }

    void Adjust()
    {
        player1 = GameObject.Find("player1");
        Vector3 p1p = player1.transform.position;
        player2 = GameObject.Find("player2");
        Vector3 p2p = player2.transform.position;

        p2p.x = p1p.x;

        player2.transform.position = p2p;
        player1.transform.position = p1p;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground2")
        {
            onGround2 = true;
        }

        if (col.gameObject.tag == "Box")
        {
            onBox = true;
        }

        if (col.gameObject.tag == "Spike" && Player1MoveManager.stopIt == false)
        {
            Player1MoveManager.curHealth -= 1;
        }
    }
}
