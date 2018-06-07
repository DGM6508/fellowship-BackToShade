using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour {

    public GameObject GameOverTxt;
    public GameObject GameWinTxt;
    public GameObject RestartButton;
    public GameObject StartButton;
    public GameObject MainMenu;
    public static bool isGameStarted = false;
    public GameObject SpikeGroup;
    public GameObject Anchor;
    public GameObject player;
    public static bool win = false;

    // Use this for initialization
    void Start () {
        GameOverTxt.SetActive(false);
        GameWinTxt.SetActive(false);
        RestartButton.SetActive(false);
        isGameStarted = false;
        SpikeGroup.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        GameHasEnded();
        GameWin();
        if (player.transform.position.x > Anchor.transform.position.x)
        {
            SpikeGroup.SetActive(true);
        }
	}

    void GameHasEnded()
    {
        if (Player1MoveManager.curHealth == 0)
        {
            GameOverTxt.SetActive(true);
            RestartButton.SetActive(true);
        }
    }

    public void OnClickRestart ()
    {
        SceneManager.LoadScene("Scene01");
        Player1MoveManager.stopIt = false;
        Player1MoveManager.curHealth = 5;
        win = false;
        isGameStarted = false;
    }

    public void OnClickStart ()
    {
        isGameStarted = true;
        MainMenu.SetActive(false);
    }

    void GameWin()
    {
        if (win)
        {
            GameWinTxt.SetActive(true);
            RestartButton.SetActive(true);
            print("123");
        }

    }
}
