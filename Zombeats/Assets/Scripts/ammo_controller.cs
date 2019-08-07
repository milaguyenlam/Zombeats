using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_controller : MonoBehaviour
{
    private Vector2 direction, target;
    private bool arrived;
    private Transform transform;
    private Rigidbody2D rb;
    public float velocity;
    private readonly Vector2 startAim = new Vector2(0f, -3.4f);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CheckIfArrived())
        {

        }
        else
        {
            Move();
        }
    }

    private bool CheckIfArrived()
    {
        if(arrived)
        {
            return true;
        }
        else
        {
            if(true)
            {
                //ammo has arrived to the target
                arrived = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private void Move()
    {

    }




}
