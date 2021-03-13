using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Ik the Ui could be make better but I just try to do everything fast...

    public GameObject PlayButton;
    public GameObject ExplainButton;
    public GameObject CloseButton;
    public GameObject logo;
    public GameObject plane;
    public GameObject player;
    public GameObject scoreObj;
    public GameObject JamMenu;
    public GameObject Hearts;
    void Start()
    {
        LeanTween.delayedCall(0.1f, ShowStartBtn);
    }

    void ShowStartBtn()
    {
        LeanTween.scale(PlayButton, new Vector3(1f, 2f, 1f), 0.5f);
        LeanTween.delayedCall(0.1f, ShowExplainBtn);
    }
    void ShowExplainBtn()
    {
        LeanTween.scale(ExplainButton, new Vector3(1f, 1f, 1f), 0.5f);
        LeanTween.delayedCall(0.1f, ShowCloseBtn);
    }
    void ShowCloseBtn()
    {
        LeanTween.scale(CloseButton, new Vector3(1f, 1f, 1f), 0.5f);
    }

    public void StartGame()
    {
        player.gameObject.transform.parent = null;
        scoreObj.SetActive(true);
        Hearts.SetActive(true);
        LeanTween.moveLocalY(player, player.transform.position.y + 1, 0.5f);
        LeanTween.moveLocalX(player, player.transform.position.x-3, 0.8f);
        LeanTween.rotateZ(player, -180f, 0.8f);
        LeanTween.moveLocalX(plane, plane.transform.position.x + 25, 1.8f).setDestroyOnComplete(true);
        LeanTween.moveLocalX(PlayButton, plane.transform.position.x + 25, 1.8f).setDestroyOnComplete(true);
        LeanTween.moveLocalX(ExplainButton, plane.transform.position.x + 25, 1.8f).setDestroyOnComplete(true);
        LeanTween.moveLocalX(CloseButton, plane.transform.position.x + 25, 1.8f).setDestroyOnComplete(true);
        LeanTween.moveLocalY(logo, logo.transform.position.y + 5, 2f).setDestroyOnComplete(true);

        InitGame();
    }

    private void InitGame()
    {
        //set spawner
        ((Spawner)GameObject.Find("Spawner").GetComponent(typeof(Spawner))).isAlive = true;
        ((Spawner)GameObject.Find("Spawner").GetComponent(typeof(Spawner))).StartGame();

        //make player controlable
        ((Player)GameObject.Find("Player").GetComponent(typeof(Player))).canMove = true;

        //set infi score
        ((GameHandler)GameObject.Find("Spawner").GetComponent(typeof(GameHandler))).StartFallScore();

    }



    public void OpenGameJamMenu()
    {
        LeanTween.move(JamMenu, new Vector3(-1.2f, 0.6f, 0),1f);
    }


    public void CloseGameJamMenu()
    {
        LeanTween.move(JamMenu, new Vector3(14.36f, 0.6f, 0), 1f);
    }

    public void CloseGame()
    {
        Application.Quit();
    }




}
