using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * GameManager.
 *
 * @author Julien Delane
 * @version 17.11.12
 * @since 17.10.24
 */
public class GameManager : MonoBehaviour
{
    /**
     * Instance of the script.
     *
     * @since 17.10.24
     */
    public static GameManager instance = null;

    /**
     * On awake of the script check if the cripts only exist one time.
     *
     * @since 17.10.24
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
    }

    /**
     * On start of the level launch a fade animation.
     *
     * @since 17.10.24
     */
	void Start()
	{
		Fading.beginFade(-1);
	}
	
    /**
     * Check every tick.
     *
     * @since 17.10.24
     */
	void Update()
	{
		
	}
	
}
