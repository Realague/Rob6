using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour
{
    
    public static LocalizationManager instance;
    private Dictionary<string, string> localizedText;
    private bool isReady = false;
    private string missingTextString = "Localized text not found";

    void Awake() 
    {
        if (instance == null)
		{
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
    public void LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string> ();
        string filePath = Path.Combine (Application.dataPath, "Lang/" + fileName + ".txt");

        if (File.Exists (filePath))
		{
            string[] data = File.ReadAllText(filePath).Split('\n');
			string[] tmp;
			foreach (string str in data)
			{
                if (str.Contains("=")) {
				    tmp = str.Split('=');
				    localizedText.Add(tmp[0], tmp[1]);
                }
			}
            Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries");
        } 
		else 
        {
            Debug.LogError("Cannot find file!");
        }
        isReady = true;
    }

    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key)) 
        {
            result = localizedText[key];
        }
        return result;
    }

    public bool GetIsReady()
    {
        return isReady;
    }

}