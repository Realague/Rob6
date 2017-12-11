using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * ProfileScript.
 *
 * @author Julien Delane
 * @version 17.11.12
 * @since 17.11.01
 */
public class ProfileScript : MonoBehaviour
{
    /**
     * The button clip.
     *
 	 * @unityParam
     * @since 17.11.12
     */
    public AudioClip buttonClip;

    /**
     * The switch clip.
     *
	 * @unityParam
     * @since 17.11.12
     */
    public AudioClip switchClip;

	/**
     * Variable to reach this object from every where.
     *
     * @since 17.11.01
     */
    public static ProfileScript instance;

	/**
     * Player profile.
     *
     * @since 17.11.01
     */
	public Profile playerProfile = null;

    /**
     * Init the object instance.
     *
     * @since 17.11.01
     */
	private void Awake()
	{
		if (instance == null)
		{
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
	}

}
