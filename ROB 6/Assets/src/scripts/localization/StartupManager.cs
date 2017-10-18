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
     * Key value to get.
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