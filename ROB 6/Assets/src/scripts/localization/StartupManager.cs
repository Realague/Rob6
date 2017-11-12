using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * StartupManager.
 *
 * @author Julien Delane
 * @version 17.10.14
 * @since 17.10.14
 */
public class StartupManager : MonoBehaviour
{
    /**
     * Wait for the ressource to be loaded to return to the menu.
     *
     * @since 17.10.14
     */
    private IEnumerator Start()
    {
        while (!LocalizationManager.instance.GetIsReady()) 
        {
            yield return null;
        }
		//reload the lang menu
        SceneManager.LoadScene("TestMenuLocalization");
    }

}