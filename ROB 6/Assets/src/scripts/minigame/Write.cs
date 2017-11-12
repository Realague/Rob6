using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * PauseMenu.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.16
 * @since 17.10.11
 */
public class Write : MonoBehaviour
{
    /**
     * The input field.
     *
     * @unityParam
     * @since 17.10.11
     */
	public InputField inputField;

    /**
     * Init the input field.
     *
     * @since 17.10.11
     */
	private void Start()
    {
		inputField.ActivateInputField();
	}

}
