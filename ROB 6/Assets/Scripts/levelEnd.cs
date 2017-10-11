using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * LevelLoader.
 * Load the given scene id otherwise load the next scene id
 *
 * @author Julien Delane
 * @version 17.10.11
 * @since 17.10.10
 */
public class levelEnd : MonoBehaviour
{

    /**
     * Var that is true when the player finish the level.
     *
     * @since 17.10.10
     */
    private bool is_end = false;

    /**
     * The time during the screen fade.
     *
     * @since 17.10.10
     */
    private float fade_time;

    /**
     * Time until the scene change.
     *
     * @unityParam
     * @since 17.10.10
     */
    public float timer = 0.4f;

    /**
     * Sound to play when the level change.
     *
     * @unityParam
     * @since 17.10.10
     */
    public AudioClip sound;

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
    void Update()
    {
        if (is_end)
        {
            //wait until the end of the animation and the sound
            timer = timer - Time.deltaTime;
            //when the animation and the sound end, load the next level
            if (timer <= 0)
            {
                if (scene == -1)
                    SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex + 1);
                else
                    SceneManager.LoadScene(scene);
            }
        }
    }

    /**
     * Launch the sound and the fade and the sound then load the level.
     *
     * @return IEnumerator
     * @since 17.10.10
     */
     //TODO: change to make this method work so we don't call the update method anymore
    IEnumerator change_level()
    {
        fade_time = GameObject.Find("fade").GetComponent<fading>().begin_fade(1);
        AudioSource.PlayClipAtPoint(sound, transform.position);
        yield return new WaitForSeconds(fade_time);
        if (scene == -1)
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex + 1);
        else
            SceneManager.LoadScene(scene);
    }

    /**
     * Launch the fade and sound pass the boolean isEnd to true.
     *
     * @param collider the object the end game object collide with
     * @since 17.10.10
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rob")
        {
            fade_time = GameObject.Find("fade").GetComponent<fading>().begin_fade(1);
            AudioSource.PlayClipAtPoint(sound, transform.position);
            change_level();
            is_end = true;
        }
    }
}