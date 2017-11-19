using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * LevelLoader.
 * Load the given scene id otherwise load the next scene id
 *
 * @author Julien Delane
 * @version 17.11.19
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
    [SerializeField]
    private AudioClip clip;

    /**
     * Id of the scene.
     *
     * @unityParam
     * @since 17.10.10
     */
    [SerializeField]
    private int scene = -1;

    /**
     * If the level is finished wait the fade animation finish to change the level.
     *
     * @since 17.10.27
     */
    private IEnumerator changeLevel()
    {
        Fading.beginFade(1);
        AudioSource.PlayClipAtPoint(clip, transform.position);
        yield return new WaitForSeconds(clip.length);
        if (scene == -1)
        {
            ProfileScript.instance.playerProfile.LevelId += 1;
            ProfileScript.instance.playerProfile.updateProfile();
            SceneManager.LoadScene(ProfileScript.instance.playerProfile.LevelId);
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