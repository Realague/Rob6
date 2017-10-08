using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class gameControl : MonoBehaviour {

    public static gameControl control;
    public static int level = 2;

	// Use this for initialization
	void Awake() {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != null)
            Destroy(gameObject);
	}
	
    public void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        Data data = new Data();
        data.level = level;
        bf.Serialize(file, data);
        file.Close();

    }

    public void load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            Data data = (Data)bf.Deserialize(file);
            level = data.level;
            file.Close();
        }
    }
}

[Serializable]
class Data
{
    public int level;
}
