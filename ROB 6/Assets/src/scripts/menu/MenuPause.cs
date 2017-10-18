using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * MenuPause.
 *
 * @author Julien Delane
 * @version 17.10.16
 * @since 17.10.10
 */
public class MenuPause : MonoBehaviour
{
    /**
     * If pause menu is displayed.
     *
     * @since 17.10.10
     */
    private bool showPauseMenu = false;

    /**
     * Time to wait before the menu open/close.
     *
     * @since 17.10.10
     */
    private float wait = 1.5f;

    /**
     * If the button is pressed.
     *
     * @since 17.10.10
     */
    private bool pressed = false;

    /**
     * If the pause key is pressed.
     *
     * @since 17.10.10
     */
    private bool isPressed = false;

    /**
     * Menu to show.
     *
     * @unityParam
     * @since 17.10.10
     */
    public GameObject canvas;

    /**
     * Sound to play when open the menu.
     *
     * @unityParam
     * @since 17.10.10
     */
    public AudioClip sound;

    /**
     * Init the menu to invisible.
     *
     * @since 17.10.10
     */
    private void Start()
    {
        canvas.SetActive(false);
	}
	
    /**
     * Play a sound and display the mnu if the pause key is pressed.
     *
     * @since 17.10.10
     */
	private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showPauseMenu = !showPauseMenu;
            wait = -1f;
            pressed = true;
        }

        if (showPauseMenu == true)
        {
            //play the sound and wait the end\\
            //if (wait == 1.5f)
              //  AudioSource.PlayClipAtPoint(sound, transform.position);
            //wait = wait - Time.deltaTime;
            //display the pause menu\\
            //if (wait <= 0)
            //{
                canvas.SetActive(true);
                Time.timeScale = 0;
            //}
        }
        else
        {
            //hide the pause menu, remove the pause and play the sound\\
            canvas.SetActive(false);
            Time.timeScale = 1;
            if (pressed == true)
            {
                AudioSource.PlayClipAtPoint(sound, transform.position);
                pressed = false;
            }
        }

        if (isPressed)
        {
            wait = wait - Time.deltaTime;
            //wait ther end of the sound played\\
            if (wait <= 0)
            {
                SceneManager.LoadScene(4);
            }
        }
    }

    /**
     * Check if the continue button is pressed.
     *
     * @since 17.10.10
     */
    public void returnToMenu()
    {
        unpaused();
        Pressed();
    }

    /**
     * Continue the game.
     *
     * @since 17.10.10
     */
    public void unpaused()
    {
        showPauseMenu = !showPauseMenu;
    }

    /**
     * If a button in the menu is pressed play a sound and continue the game.
     *
     * @since 17.10.10
     */
    private void Pressed()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        isPressed = true;
        wait = 1.5f;
    }

}
