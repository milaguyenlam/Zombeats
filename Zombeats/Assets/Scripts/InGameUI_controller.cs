﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI_controller : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject AfterGamePanel;
    public static bool GamePaused = false;
    public GameObject[] hearts;
    private int heart_counter = 2;

    public void Pause()
    {
        PauseMenu.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = true;
        Debug.Log("Paused!");
    }

    public bool GetPaused()
    {
        return GamePaused;
    }

    public void SetPausedAsFalse()
    {
        GamePaused = false;
    }

    public void disableHeart()
    {
        Debug.Log(heart_counter);
        if (heart_counter > 0)
        {
            hearts[heart_counter].SetActive(false);
            heart_counter--;
        }
    }

    public void GameOver()
    { 
        Debug.Log("GameOver");
        gameObject.SetActive(false);
        AfterGamePanel.SetActive(true);
        AfterGamePanel.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Win()
    {
        Debug.Log("Win");
        gameObject.SetActive(false);
        AfterGamePanel.SetActive(true);
        AfterGamePanel.transform.GetChild(1).gameObject.SetActive(true);
    }

}
