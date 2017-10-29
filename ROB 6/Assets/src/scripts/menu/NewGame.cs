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
 * @since 17.10.14
 */
public class NewGame : MonoBehaviour
{
    /**
     * Continue game.
     *
     * @since 17.10.14
     */
	private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GameControl.level = 2;
            //GameControl.control.save();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
	}

}
