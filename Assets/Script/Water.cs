using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    public float moveSpeed;

    void Update ()
    {
        if (GameSceneManager.isGameStarted == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Player1MoveManager.curHealth = 0;
            print(Player1MoveManager.curHealth);
        }
    }
}
