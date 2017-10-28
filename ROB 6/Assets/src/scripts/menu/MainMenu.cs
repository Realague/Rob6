using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * MainMenu.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.28
 * @since 17.10.10
 */
public class MainMenu : MonoBehaviour
{
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
	private void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            AudioSource.PlayClipAtPoint(switchClip, transform.position);
            if (i == 0)
            {
                i = 2;
            }
            else
            {
                i--;
            }
            transform.position = new Vector2(transform.position.x, i * -1.75f);
        }
        else if (Input.GetKeyDown("s"))
        {
            AudioSource.PlayClipAtPoint(switchClip, transform.position);
            if (i == 2)
            {
                i = 0;
            }
            else
            {
                ++i;
            }
            transform.position = new Vector2(transform.position.x, i * -1.75f);
        }
        StartCoroutine(select());
    }

    /**
     * Check if the player select an option and launch it.
     *
     * @since 17.10.28
     */
    private IEnumerator select()
    {
        if (Input.GetKeyDown("space"))
        {
            switch (i)
            {
                case 0:
                    AudioSource.PlayClipAtPoint(buttonClip, transform.position);
                    yield return new WaitForSecondsRealtime(buttonClip.length);
                    //GameControl.control.load();
                    //SceneManager.LoadScene(GameControl.level);
                    break;
                case 1:
                    AudioSource.PlayClipAtPoint(buttonClip, transform.position);
                    yield return new WaitForSecondsRealtime(buttonClip.length);
                    SceneManager.LoadScene(1);
                    break;
                case 2:
                    AudioSource.PlayClipAtPoint(buttonClip, transform.position);
                    yield return new WaitForSecondsRealtime(buttonClip.length);
                    Application.Quit();
                    break;
            }
        }
    }

}
