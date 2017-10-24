using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * LevelLoader.
 * Load the given scene id otherwise load the next scene id
 *
 * @author Julien Delane
 * @version 17.10.16
 * @since 17.10.10
 */
public class LevelLoader : MonoBehaviour
{
    /**
     * Var that is true when the player finish the level.
     *
     * @since 17.10.10
     */
    private bool isEnd = false;

    /**
     * The time during the screen fade.
     *
     * @since 17.10.10
     */
    private float fadeDuration;

    /**
     * Time until the scene change.
     *
     * @unityParam
     * @since 17.10.10
     */
    public float timer = 0.4f;

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
     * @since 17.10.10
     */
    private void Update()
    {
        if (isEnd)
        {
            //wait until the end of the animation and the clip
            timer = timer - Time.deltaTime;
            //when the animation and the clip end, load the next level
            if (timer <= 0)
            {
                if (scene == -1)
                {
                    SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex + 1);
                }
                else
                {
                    SceneManager.LoadScene(scene);
                }
            }
        }
    }

    /**
     * Launch the clip and the fade and the clip then load the level.
     *
     * @return IEnumerator
     * @since 17.10.10
     */
     //TODO: change to make this method work so we don't call the update method anymore
    private IEnumerator changeLevel()
    {
        fadeDuration = GameObject.Find("Fade").GetComponent<Fading>().begin_fade(1);
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
        if (collider.tag == "Rob")
        {
            fadeDuration = GameObject.Find("Fade").GetComponent<Fading>().begin_fade(1);
            AudioSource.PlayClipAtPoint(clip, transform.position);
            changeLevel();
            isEnd = true;
        }
    }
}