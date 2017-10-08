using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fading : MonoBehaviour
{

    public Texture2D fade_out_texture;
    public float fade_speed = 1.0f;

    private int fade_dir = -1;
    private int draw_depth = -1000;
    private float alpha = 1.0f;

    void OnGUI ()
    {
        //fade out/in the alpha value using a direction a speed deltatime//
        alpha += fade_dir * fade_speed * Time.deltaTime;
        // force (clamp) set the number between 0 and 1//
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = draw_depth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fade_out_texture);
    }

    public float begin_fade (int direction)
    {
            fade_dir = direction;
            return (fade_speed); 
    }

    void    on_level_was_loaded()
    {
        begin_fade(-1);
    }
}
