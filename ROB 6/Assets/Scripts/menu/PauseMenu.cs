using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * PauseMenu.
 *
 * @author Julien Delane
 * @version 17.10.15
 * @since 17.10.11
 */
public class PauseMenu : MonoBehaviour
{
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
     * Hide the menu when the level start.
     *
     * @since 17.10.11
     */
    private void Start()
    {
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
            Time.timeScale = 0;
            MoveCursor.close = false;
            menu.SetActive(true);
            active = true;
            PlayerController.stop = true;
        }
       else if (Input.GetKeyDown(KeyCode.Escape) && active == true || MoveCursor.close == true)
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            active = false;
            PlayerController.stop = false;
        }
    }

}
