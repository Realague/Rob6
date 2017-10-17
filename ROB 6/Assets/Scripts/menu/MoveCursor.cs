using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * MoveCursor.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.14
 * @since 17.10.11
 */
public class MoveCursor : MonoBehaviour
{
    /**
     * Index in the menu.
     *
     * @since 17.10.11
     */
    private int i = 0;

    /**
     * Define if the menu is open or close.
     *
     * @unityParam
     * @since 17.10.11
     */
    public static bool close;

    /**
     * Set the menu to open.
     *
     * @since 17.10.11
     */
	private void Start()
    {
        close = false;
	}
	
    /**
     * Move the cursor position when press the correspondent key.
     *
     * @since 17.10.11
     */
	private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            i--;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            i++;
        }
        if (i > 1)
        {
            i = 0;
        }
        else if (i < 0)
        {
            i = 1;
        }
        switch (i)
        {
            case 0:
                transform.position = new Vector2(transform.position.x, 750);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    close = true;
                }
                break;
            case 1:
                transform.position = new Vector2(transform.position.x, 550);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Time.timeScale = 1;
                    PlayerController.stop = false;
                    SceneManager.LoadScene(0);
                }
                break;
        }
	}
}
