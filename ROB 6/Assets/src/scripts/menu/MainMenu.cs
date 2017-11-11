using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;
using System;

/**
 * MainMenu.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.31
 * @since 17.10.10
 */
public class MainMenu : MonoBehaviour
{
    /**
     * The button clip.
     *
 	 * @unityParam
     * @since 17.10.28
     */
    public AudioClip buttonClip;

    /**
     * The switch clip.
     *
	 * @unityParam
     * @since 17.10.28
     */
    public AudioClip switchClip;

    /**
     * The index of the cursor.
     *
     * @since 17.10.10
     */
    private int i = 0;

    /**
     * Button list.
     *
     * @since 17.11.08
     */
     public List<GameObject> buttons;

    /**
     * Load the localization when the game start.
     *
     * @since 17.10.10
     */
    private void Start()
    {
        if (LocalizationManager.instance.GetLocalizedValue("LANGUAGE.CODE").CompareTo("Localized text not found") == 0)
        {
            LocalizationManager.instance.LoadLocalizedText("fr_fr");
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }

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
                i = 4;
            }
            else
            {
                i--;
            }
            transform.position = new Vector2(transform.position.x, buttons[i].transform.position.y);
        }
        else if (Input.GetKeyDown("s"))
        {
            AudioSource.PlayClipAtPoint(switchClip, transform.position);
            if (i == 4)
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
     * @since 17.10.28
     */
    private IEnumerator select()
    {
        if (Input.GetKeyDown("space"))
        {
            AudioSource.PlayClipAtPoint(buttonClip, transform.position);
            switch (i)
            {
                case 0:
                    Profile.getLastProfileEdited();
                    yield return new WaitForSecondsRealtime(buttonClip.length);
                    SceneManager.LoadScene(ProfileScript.instance.playerProfile.LevelId);
                    break;
                case 1:
                    yield return new WaitForSecondsRealtime(buttonClip.length);
                    SceneManager.LoadScene("ProfileCreation");
                    break;
                case 2:
                    //TODO: profile list
                    yield return new WaitForSecondsRealtime(buttonClip.length);
                    SceneManager.LoadScene("ProfileList");
                    break;
                case 3:
                    //TODO: option
                    yield return new WaitForSecondsRealtime(buttonClip.length);
                    break;
                case 4:
                    yield return new WaitForSecondsRealtime(buttonClip.length);
                    Application.Quit();
                    break;
            }
        }
    }

}
