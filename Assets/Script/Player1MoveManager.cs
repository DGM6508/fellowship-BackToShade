using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1MoveManager : MonoBehaviour {

    public int playerSpeed = 10;
    //public bool facingRight = true;
    public int playerJumpPower1 = 1250;
    public bool onGround1 = false;
    private bool onBox = false;
    public static bool stopIt = false;

    public GameObject player1;
    public GameObject player2;

    public static int curHealth;

    void Start()
    {
        curHealth = 5;
    }

    void Update () {
        PlayerMove();
        Adjust();
        GameOver();
	}

    void PlayerMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("space")) {
            if(onGround1 == true || onBox == true)
            {
                Jump();
            }
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower1);
        onGround1 = false;
        onBox = false;
    }

    void Adjust()
    {
        player1 = GameObject.Find("player1");
        Vector3 p1p = player1.transform.position;
        player2 = GameObject.Find("player2");
        Vector3 p2p = player2.transform.position;

        float chaseTime = 1f;
        float chaseSpeed = Mathf.Abs(p1p.x - p2p.x) / chaseTime;

        if (p2p.x < p1p.x)
        {
            p2p.x += chaseSpeed * Time.deltaTime;
        }

        if (p2p.x > p1p.x)
        {
            p2p.x -= chaseSpeed * Time.deltaTime;
        }

        player2.transform.position = p2p;
        player1.transform.position = p1p;

    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Ground1")
        {
            onGround1 = true;
        }

        if(col.gameObject.tag == "Box")
        {
            onBox = true;
        }

        if(col.gameObject.tag == "Spike" && stopIt == false)
        {
            curHealth -= 1;

        }
    }

    void GameOver()
    {
        if (curHealth == 0)
        {
            stopIt = true;
        }
    }


    //Player Flip Preparation
    /*if (moveX < 0.0f && facingRight == false)
    {
        FlipPlayer();
    } else if (moveX > 0.0f && facingRight == true) {
        FlipPlayer();
    }*/
}
