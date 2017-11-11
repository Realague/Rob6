using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * PauseMenu.
 *
 * @author Julien Delane
 * @version 17.10.31
 * @since 17.10.11
 */
public class PauseMenu : MonoBehaviour
{
    /**
     * Index in the menu.
     *
     * @since 17.10.28
     */
     private int i = 1;
    
    /**
     * The button clip.
     *
     * @since 17.10.28
     */
    public AudioClip buttonClip;

    /**
     * The switch clip.
     *
     * @since 17.10.28
     */
    public AudioClip switchClip;

    /**
     * The cursor.
     *
     * @unityParam
     * @since 17.10.11
     */
    public GameObject cursor;

    /**
     * The menu.
     *
     * @unityParam
     * @since 17.10.11
     */
    public GameObject menu;

    /**
     * Define if the menu is hidden or not.
     *
     * @since 17.10.11
     */
    private bool active;

    /**
     * The position of the cursor.
     *
     * @since 17.10.31
     */
    private float cursorPosition;

    /**
     * Offset between index.
     *
     * @since 17.10.31
     */
    private float offset = -250;

    /**
     * Hide the menu when the level start.
     *
     * @since 17.10.11
     */
    private void Start()
    {
        cursorPosition = cursor.transform.position.y;
        menu.SetActive(false);
        active = false;
    }

    /**
     * Catch the different action in the pause menu.
     *
     * @since 17.10.11
     */
	private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && active == false)
        {
            menu.SetActive(true);
            Time.timeScale = 0;
            active = true;
            PlayerController.stop = true;
        }
       else if (active == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            active = false;
            PlayerController.stop = false;
        }
        if (active == true)
        {
            if (Input.GetKeyDown("s"))
            {
                AudioSource.PlayClipAtPoint(switchClip, transform.position);
                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i--;
                }
                cursor.transform.position = new Vector2(cursor.transform.position.x, cursorPosition + offset * i);
            }
            else if (Input.GetKeyDown("z"))
            {
                AudioSource.PlayClipAtPoint(switchClip, transform.position);
                if (i == 1)
                {
                    i = 0;
                }
                else
                {
                    ++i;
                }
                cursor.transform.position = new Vector2(cursor.transform.position.x, cursorPosition + offset * i);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(select());
            }
        }
    }

    /**
     * Check if the player select an option and launch it.
     *
     * @since 17.10.28
     */
    private IEnumerator select()
    {
        switch (i)
        {
            case 0:
                PlayerController.stop = false;
                AudioSource.PlayClipAtPoint(buttonClip, transform.position);
                yield return new WaitForSecondsRealtime(buttonClip.length);
                ProfileScript.instance.playerProfile.updateProfile();
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
                break;
            case 1:
                AudioSource.PlayClipAtPoint(buttonClip, transform.position);
                yield return new WaitForSecondsRealtime(buttonClip.length);
                Time.timeScale = 1;
                menu.SetActive(false);
                active = false;
                PlayerController.stop = false;
                break;

            }
    }

}
