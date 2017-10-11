using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Fading.
 *
 * @author Julien Delane
 * @version 17.10.11
 * @since 17.10.09
 */
public class fading : MonoBehaviour
{

    /**
     * Fading texture.
     *
     * @unityParam
     * @since 17.10.09
     */
    public Texture2D fade_out_texture;

    /**
     * Fading speed.
     *
     * @unityParam
     * @since 17.10.09
     */
    public float fade_speed = 1.0f;

    /**
     * If equals -1 fade in and if equals 1 fade out.
     *
     * @since 17.10.09
     */
    private int fade_dir = -1;

    /**
     * Fade depth.
     *
     * @since 17.10.09
     */
    private int draw_depth = -1000;

    /**
     * Alpha of the fade.
     *
     * @since 17.10.09
     */
    private float alpha = 1.0f;

    /**
     * Launch a fade animation.
     *
     * @since 17.10.09
     */
    public void OnGUI()
    {
        //fade out/in the alpha value using a direction a speed delta time
        alpha += fade_dir * fade_speed * Time.deltaTime;
        // force (clamp) set the number between 0 and 1
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

    public void on_level_was_loaded()
    {
        begin_fade(-1);
    }
}
