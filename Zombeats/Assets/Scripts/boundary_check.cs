﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary_check : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public GameObject HUD;
    private float HUDheight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        HUDheight = HUD.GetComponent<SpriteRenderer>().bounds.size.y;
 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -1 * screenBounds.x + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -1 * screenBounds.y + objectHeight + HUDheight, screenBounds.y - objectHeight);

        transform.position = viewPos;
    }
}


