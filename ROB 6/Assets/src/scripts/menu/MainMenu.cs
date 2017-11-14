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
 * @version 17.11.12
 * @since 17.10.10
 */
public class MainMenu : MonoBehaviour
{
    /**
     * The index of the cursor.
     *
     * @since 17.10.10
     */
    private bool canContinue = true;

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
        if (Profile.getAllProfile().Count == 0)
        {
            canContinue = false;
            Destroy(buttons[1]);
            Destroy(buttons[2]);
        }
        string lang = Lang.getLanguage();
        string code = LocalizationManager.instance.GetLocalizedValue("LANGUAGE.CODE");
        if (code.CompareTo("Localized text not found") == 0 || code.CompareTo(lang) != 0)
        {
            LocalizationManager.instance.LoadLocalizedText(lang);
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
        transform.position = new Vector2(transform.position.x, buttons[0].transform.position.y);
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
            AudioSource.PlayClipAtPoint(ProfileScript.instance.switchClip, transform.position);
            if (i == 0)
            {
                i = 4;
            }
            else if (!canContinue && i == 3)
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
            if (i == 4)
            {
                i = 0;
            }
            else if (!canContinue && i == 0)
            {
                i = 3;
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
            AudioSource.PlayClipAtPoint(ProfileScript.instance.buttonClip, transform.position);
            switch (i)
            {
                case 0:
                    yield return new WaitForSecondsRealtime(ProfileScript.instance.buttonClip.length);
                    SceneManager.LoadScene("ProfileCreation");
                    break;
                case 1:
                    Profile.getLastProfileEdited();
                    yield return new WaitForSecondsRealtime(ProfileScript.instance.buttonClip.length);
                    SceneManager.LoadScene(ProfileScript.instance.playerProfile.LevelId);
                    break;
                case 2:
                    yield return new WaitForSecondsRealtime(ProfileScript.instance.buttonClip.length);
                    SceneManager.LoadScene("ProfileList");
                    break;
                case 3:
                    yield return new WaitForSecondsRealtime(ProfileScript.instance.buttonClip.length);
                    SceneManager.LoadScene(3);
                    break;
                case 4:
                    yield return new WaitForSecondsRealtime(ProfileScript.instance.buttonClip.length);
                    Application.Quit();
                    break;
            }
        }
    }

}
