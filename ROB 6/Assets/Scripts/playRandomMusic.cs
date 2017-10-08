using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playRandomMusic : MonoBehaviour {

    Object[] music;
    public string directory;

    void Awake()
    {
        //load all the music in the folder specified in parameter\\
        music = Resources.LoadAll(directory, typeof(AudioClip));
        GetComponent<AudioSource>().clip = music[0] as AudioClip;
    }

    // Use this for initialization
    void Start ()
    {
        GetComponent<AudioSource>().Play();	
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!GetComponent<AudioSource>().isPlaying)
        {
            playRandomClip();
        }
	}

    void playRandomClip ()
    {
        GetComponent<AudioSource>().clip = music[Random.Range(0, music.Length)] as AudioClip;
        GetComponent<AudioSource>().Play();
    }
}
