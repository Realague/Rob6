using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * PauseMenu.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.11
 * @since 17.10.11
 */
public class write : MonoBehaviour {

    /**
     * The input field.
     *
     * @unityParam
     * @since 17.10.11
     */
	public InputField slc;

    /**
     * Init the input field.
     *
     * @unityParam
     * @since 17.10.11
     */
	void Start () {
		slc.ActivateInputField();
	}
	
	void Update () {
	}
}
