using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * MainMenu.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.11
 * @since 17.10.10
 */
public class mainMenu : MonoBehaviour {

    /**
     * The position of the cursor.
     *
     * @since 17.10.10
     */
    private int i = 0;

    /**
     * Check if the key to move the cursor position are pressed then call the method to move the cursor and call the select method.
     *
     * @since 17.10.10
     */
	void Update () {
        if (Input.GetKeyDown("s"))
            i++;
        else if (Input.GetKeyDown("z"))
            i--;
        if (i < 0)
            i = 2;
        else if (i > 2)
            i = 0;
        cursorPosition();
        select();
    }

    /**
     * Move the cursor.
     *
     * @since 17.10.10
     */
    void cursorPosition()
    {
        if (i == 0)
            transform.position = new Vector2(4, 0);
        else if (i == 1)
            transform.position = new Vector2(4, -1.75f);
        else if (i == 2)
            transform.position = new Vector2(4, -3.5f);
    }

    /**
     * Check if the player select an option and do it.
     *
     * @since 17.10.10
     */
    void select()
    {
        if (Input.GetKeyDown("space"))
            switch (i)
            {
                case 0:
                    gameControl.control.load();
                    SceneManager.LoadScene(gameControl.level);
                    break;
                case 1:
                    SceneManager.LoadScene(1);
                    break;
                case 2:
                    Application.Quit();
                    break;

            }
    }
}
