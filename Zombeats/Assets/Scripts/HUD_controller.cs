using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResizeSpriteToScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResizeSpriteToScreen()
    {
        //resizing to fit camera precisely - rescaling width and move y

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr == null) { return; }

        float startY = transform.localScale.y;
        float width = sr.sprite.bounds.size.x;
        float worldScreenheight = Camera.main.orthographicSize * 2.0f;
        float worldScreenwidth = worldScreenheight / Screen.height * Screen.width;

        transform.localScale = new Vector2(worldScreenwidth / width, startY);

        float height = sr.bounds.size.y/2;

        Debug.Log(worldScreenheight + " " + height);
        Debug.Log(-worldScreenheight / 2.0f + height);
        transform.position = new Vector2(0.0f, -worldScreenheight/2.0f + height);

    }
}
