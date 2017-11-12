using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.SceneManagement;

/**
 * ProfileCreation.
 *
 * @author Julien Delane
 * @version 17.10.29
 * @since 17.10.29
 */
public class ProfileCreation : MonoBehaviour
{
    /**
     * The input field.
     *
     * @unityParam
     * @since 17.10.29
     */
	public InputField inputField;

    /**
     * Init the input field.
     *
     * @since 17.10.29
     */
	private void Start()
    {
		inputField.ActivateInputField();
	}

    private void Update()
    {
        if (inputField.text.CompareTo("") != 0 && Input.GetKeyDown(KeyCode.Return))
        {
            Profile.insertProfile(inputField.text);
            Profile.getLastProfileEdited();
            SceneManager.LoadScene(ProfileScript.instance.playerProfile.LevelId);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

}
