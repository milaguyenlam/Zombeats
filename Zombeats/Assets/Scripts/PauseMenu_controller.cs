using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu_controller : MonoBehaviour
{
    public GameObject InGameUI;

    public void Resume()
    {
        gameObject.SetActive(false);
        InGameUI.SetActive(true);
        Time.timeScale = 1f;
        InGameUI.GetComponent<InGameUI_controller>().SetPausedAsFalse();
        Debug.Log("Resume!");
    }

    public void Settings()
    {
        //are in game settings even necessary?
        //opening settings menu w Scene manager
        //quit game?
        Debug.Log("Open Settings menu ...");
    }

    public void Quit()
    {
        Application.Quit();
        //Quit the whole game or get back to main menu
        Debug.Log("Quitting the game ...");
    }
}
