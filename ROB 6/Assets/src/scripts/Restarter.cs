using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Restarter.
 *
 * @author Julien Delane
 * @version 17.10.25
 * @since 17.10.11
 */
public class Restarter : MonoBehaviour
{
    /**
     * Define if the scene must restart.
     *
     * @since 17.10.11
     */
    public static bool isDead = false;

    /**
     * Death animation.
     *
     * @unityParam
     * @since 17.10.11
     */
    Animator animator;

    /**
     * Death clip.
     *
     * @unityParam
     * @since 17.10.11
     */
    public AudioClip clip;

    /**
     * Init animator.
     *
     * @since 17.10.11
     */
    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    /**
     * Check if the player is dead or press the key to restart and then wait the fade animation to end and restart the level.
     *
     * @since 17.10.11
     */
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || isDead)
        {
            StartCoroutine(death(isDead));
            isDead = false;
        }
    }

    /**
     * When the level need to be reload launch the fade animation and clip and then wait the fade animation end to reload the level.
     *
     * @param isDead definbe is the player isDead.
     * @since 17.10.05
     */
    private IEnumerator death(bool isDead)
    {
        float fadeDuration = Fading.beginFade(1);
        if (isDead)
        {
    //        animator.SetBool("death", true);
        }
        AudioSource.PlayClipAtPoint(clip, transform.position);
        yield return new WaitForSecondsRealtime(fadeDuration);
        PlayerController.facingRight = true;
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }

    /**
     * Check if the player hit an object that kill him and set the player to death.
     *
     * @param collider object the player hit
     * @since 17.10.11
     */
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.CompareTo("Death") == 0 && !isDead)
        {
            isDead = true;
        }
    }

}
