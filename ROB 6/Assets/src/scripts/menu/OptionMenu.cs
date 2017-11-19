using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * MainMenu.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.11.19
 * @since 17.10.10
 */
public class OptionMenu : MonoBehaviour
{
    /**
     * The index of the cursor.
     *
     * @since 17.11.11
     */
    private int i = 0;

    /**
     * Button list.
     *
     * @unityParam
     * @since 17.11.11
     */
    [SerializeField]
    private List<GameObject> buttons;

    /**
     * Load the localization when the game start.
     *
     * @since 17.11.11
     */
    private void Start()
    {
		transform.position = new Vector2(transform.position.x, buttons[i].transform.position.y);
    }

    /**
     * Check if the key to move the cursor position are pressed then call the method to move the cursor and call the select method.
     *
     * @since 17.11.11
     */
	private void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            AudioSource.PlayClipAtPoint(ProfileScript.instance.switchClip, transform.position);
            if (i == 0)
            {
                i = 0;
            }
            else
            {
                i--;
            }
            transform.position = new Vector2(transform.position.x, buttons[i].transform.position.y);
        }
        else if (Input.GetKeyDown("s"))
        {
            AudioSource.PlayClipAtPoint(ProfileScript.instance.switchClip, transform.position);
            if (i == 0)
            {
                i = 0;
            }
            else
            {
                ++i;
            }
            transform.position = new Vector2(transform.position.x, buttons[i].transform.position.y);
        }
        StartCoroutine(select());
    }

    /**
     * Check if the player select an option and launch it.
     *
     * @since 17.11.11
     */
    private IEnumerator select()
    {
        if (Input.GetKeyDown("space"))
        {
            AudioSource.PlayClipAtPoint(ProfileScript.instance.buttonClip, transform.position);
            switch (i)
            {
                case 0:
                    yield return new WaitForSecondsRealtime(ProfileScript.instance.buttonClip.length);
                    SceneManager.LoadScene("LangSelection");
                    break;
            }
        }
    }

}
