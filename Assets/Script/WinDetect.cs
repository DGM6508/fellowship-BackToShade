using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDetect : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameSceneManager.win = true;
        }
    }
}
