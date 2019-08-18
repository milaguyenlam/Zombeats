using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_controller : MonoBehaviour
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

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr == null) { return; }
        transform.localScale = new Vector3(1, 1, 1);
        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenheight = Camera.main.orthographicSize * 2.0f;
        float worldScreenwidth = worldScreenheight / Screen.height * Screen.width;

        transform.localScale = new Vector2(worldScreenwidth / width, worldScreenheight / height);
        transform.position = new Vector3(0, 0, 0);


    }
}
