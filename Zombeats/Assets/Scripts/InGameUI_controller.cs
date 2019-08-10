using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI_controller : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool GamePaused = false;
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

}
