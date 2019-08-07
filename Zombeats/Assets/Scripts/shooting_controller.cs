using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_controller : MonoBehaviour
{
    public float AimRatio;
    public GameObject Ammo;
    private Vector2 startTouch, swipeDelta, Aim;
    private readonly Vector2 startAim = new Vector2(0f, -3.4f);
    private bool isDraging = false;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        transform.position = Aim = startAim;
    }

    private void PlaceAmmo()
    {
        Instantiate(Ammo, Aim, Quaternion.identity);
    }

    private void ShootAmmo()
    {
        
    }

    private void Update()
    {
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                startTouch = Input.touches[0].position;
                isDraging = true;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                PlaceAmmo();
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
