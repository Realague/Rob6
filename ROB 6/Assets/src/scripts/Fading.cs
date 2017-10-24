﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Fading.
 *
 * @author Julien Delane
 * @version 17.10.23
 * @since 17.10.09
 */
public class Fading : MonoBehaviour
{

    /**
     * Fading texture.
     *
     * @unityParam
     * @since 17.10.09
     */
    public Texture2D fadeOutTexture;

    /**
     * Fading speed.
     *
     * @unityParam
     * @since 17.10.09
     */
    public float fadeSpeed = 1.0f;

    /**
     * If equals -1 fade in and if equals 1 fade out.
     *
     * @since 17.10.09
     */
    private int fadeDir = -1;

    /**
     * Fade depth.
     *
     * @since 17.10.09
     */
    private int drawDepth = -1000;

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
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        // force (clamp) set the number between 0 and 1
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }


    public float begin_fade (int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    public void on_level_was_loaded()
    {
        begin_fade(-1);
    }
}
