using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_controller : MonoBehaviour
{
    public int player_lives;
    public GameObject InGameUI;
    // Start is called before the first frame update
    void Start()
    {
        ResizeSpriteToScreen();
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

        transform.position = new Vector2(0.0f, -worldScreenheight/2.0f + height);

    }


    public void gotHit()
    {
        player_lives--;
        if(player_lives <= 0)
        {
            InGameUI.GetComponent<InGameUI_controller>().GameOver();
        }
        InGameUI.GetComponent<InGameUI_controller>().disableHeart();
    }



}
