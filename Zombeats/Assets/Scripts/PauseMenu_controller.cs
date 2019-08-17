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
}
