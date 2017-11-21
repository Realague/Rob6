using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/**
 * LocalizationManager.
 *
 * @author Julien Delane
 * @version 17.11.19
 * @since 17.10.14
 */
public class LocalizationManager : MonoBehaviour
{
    /**
     * Variable to reach this object from every where.
     *
     * @since 17.10.14
     */
    public static LocalizationManager instance;

    /**
     * The dictionary containing the key and the translation.
     *
     * @since 17.10.14
     */
    private Dictionary<string, string> localizedText;

    /**
     * Define if the resource localization are loaded.
     *
     * @since 17.10.14
     */
    private bool isReady = false;

    /**
     * Init the object instance.
     *
     * @since 17.10.14
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
    
    /**
     * Load the translation.
     *
     * @param fileName of the lang file
     * @since 17.10.14
     */
    public void LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Application.dataPath + "/StreamingAssets/lang/" + fileName.Substring(0, fileName.Length - 1) + ".lang";
        if (File.Exists(filePath))
		{
            string[] data = File.ReadAllText(filePath).Split('\n');
			string[] tmp;
			foreach (string str in data)
			{
                if (str.Contains("="))
                {
				    tmp = str.Split('=');
				    localizedText.Add(tmp[0], tmp[1]);
                }
			}
            Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries");
        }
		else
        {
            Debug.LogError("Cannot find file! " + filePath);
        }
        isReady = true;
    }

    /**
     * Get the translation.
     *
     * @param key of the translation
     * @since 17.10.14
     */
    public string GetLocalizedValue(string key)
    {
        string result;
        if (localizedText != null && localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        else
        {
            result = "Localized text not found";
        }
        return result;
    }

    /**
     * Get isReady variable.
     *
     * @since 17.10.14
     */
    public bool GetIsReady()
    {
        return isReady;
    }

}