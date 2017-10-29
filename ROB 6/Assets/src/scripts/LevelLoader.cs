﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * LevelLoader.
 * Load the given scene id otherwise load the next scene id
 *
 * @author Julien Delane
 * @version 17.10.27
 * @since 17.10.10
 */
public class LevelLoader : MonoBehaviour
{
    /**
     * clip to play when the level change.
     *
     * @unityParam
     * @since 17.10.10
     */
    public AudioClip clip;

    /**
     * Id of the scene.
     *
     * @unityParam
     * @since 17.10.10
     */
    public int scene = -1;

    /**
     * If the level is finished wait the fade animation finish to change the level.
     *
     * @since 17.10.27
     */
    private IEnumerator changeLevel()
    {
        float fadeDuration = Fading.beginFade(1);
        AudioSource.PlayClipAtPoint(clip, transform.position);
        yield return new WaitForSeconds(fadeDuration);
        if (scene == -1)
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }

    /**
     * Launch the fade and clip pass the boolean isEnd to true.
     *
     * @param collider the object the end game object collide with
     * @since 17.10.10
     */
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.CompareTo("Rob") == 0)
        {
            StartCoroutine(changeLevel());
        }
    }
}