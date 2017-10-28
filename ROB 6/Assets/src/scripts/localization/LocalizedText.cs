using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * LocalizedText.
 *
 * @author Julien Delane
 * @version 17.10.14
 * @since 17.10.14
 */
public class LocalizedText : MonoBehaviour
{
    /**
     * Key value to get.
     *
     * @unityParam
     * @since 17.10.14
     */
    public string key;

    /**
     * On start change the text value to fit with the localization.
     *
     * @unityParam
     * @since 17.10.14
     */
    private void Start()
    {
        Text text = GetComponent<Text>();
        text.text = LocalizationManager.instance.GetLocalizedValue(key);
    }

}