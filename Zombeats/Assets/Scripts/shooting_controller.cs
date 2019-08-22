using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class shooting_controller : MonoBehaviour
{
    public float AimRatio;
    public GameObject Ammo;
    private Vector2 startTouch, swipeDelta, Aim;
    public readonly Vector2 startAim = new Vector2(0f, -3.4f);
    private bool isDraging = false;
    private bool reloaded = true;
    public float reloadTime;


    //variables for disabling aiming
    public GameObject InGameUI;
    private bool GamePaused;




    public Vector2 SwipeDelta { get { return swipeDelta; } }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        transform.position = Aim = startAim;
    }

    private void PlaceAmmo()
    {
        GameObject ammo = (GameObject)Instantiate(Ammo, startAim, Quaternion.identity);
        ammo.GetComponent<ammo_controller>().loadTarget(Aim);
        ammo.GetComponent<ammo_controller>().loadType(ammo_controller.Type.VEGAN); //Type depending on swipebar state
        reloaded = false;
        Invoke("reload", reloadTime);
    }

    private void reload()
    {
        reloaded = true;
    }

    private void Update()
    {
        // cant aim when game is paused
        GamePaused = InGameUI.GetComponent<InGameUI_controller>().GetPaused();
        if (GamePaused || EventSystem.current.IsPointerOverGameObject()) //wont to anything when clicking on an UI object
        {
            return;
        }


        Aim = transform.position;
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                startTouch = Input.touches[0].position;
                isDraging = true;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                if (reloaded)
                {
                    PlaceAmmo();
                }
                else
                {
                    Debug.Log("not reloaded yet");
                }
                isDraging = false;
                Reset();
            }
        }

        if (isDraging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
                Aim = -swipeDelta * AimRatio + startAim;
                transform.position = Aim;
            }
        }
    }

}
