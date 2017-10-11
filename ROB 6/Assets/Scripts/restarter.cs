using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Restarter.
 *
 * @author Julien Delane
 * @version 17.10.11
 * @since 17.10.11
 */
public class restarter : MonoBehaviour {

    /**
     * Time between the death and reload the level.
     *
     * @since 17.10.11
     */
    private float timer = 0.5f;

    /**
     * Define if the scene must restart.
     *
     * @since 17.10.11
     */
    private bool death = false;

    /**
     * Death animation.
     *
     * @unityParam
     * @since 17.10.11
     */
    Animator anim;

    /**
     * Death sound.
     *
     * @unityParam
     * @since 17.10.11
     */
    public AudioClip sound;

    /**
     * Init animator.
     *
     * @since 17.10.11
     */
    private void Start()
    {
        //anim = GetComponent<Animator>();
    }

    /**
     * Check if the player is dead or press the key to restart and then wait the fade animation to end and restart the level.
     *
     * @since 17.10.11
     */
    void Update()
    {
        //catch the if player press r
        if ((Input.GetKeyDown(KeyCode.R) || playerController.death == true) && !death)
        {
            GameObject.Find("fade").GetComponent<fading>().begin_fade(1);
            death = true;
            playerController.death = false;
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
        //wait the end of the sound and animation to restart the lvl
        if (death)
        {
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                playerController.facingRight = true;
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
                //anim.SetBool("death", false);
            }
        }
    }

    /*IEnumerator dead()
    {
        Debug.Log("ps");
        float fade_time = 7;
        //fade_time = GameObject.Find("fade").GetComponent<fading>().begin_fade(1);
        AudioSource.PlayClipAtPoint(sound, transform.position);
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        yield return new WaitForSeconds(fade_time);
    }*/

    /**
     * Check if the player hit an object that kill him and set the player to death.
     *
     * @param collider object the player hit
     * @since 17.10.11
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        //play the sound and the animation of death
        if (other.tag == "Death" && !death)
        {
            GameObject.Find("fade").GetComponent<fading>().begin_fade(1);
            AudioSource.PlayClipAtPoint(sound, transform.position);
            //dead();
            //anim.SetBool("death", true);
            death = true;
        }
    }
}
