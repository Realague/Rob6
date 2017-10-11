using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * PlayRandomClips.
 *
 * @author Julien Delane
 * @version 17.10.10
 * @since 17.10.10
 */
public class playRandomMusic : MonoBehaviour {

    /**
     * List of clips.
     *
     * @since 17.10.10
     */
    private Object[] music;

    /**
     * Directory where are soundtracks.
     *
     * @unityParam
     * @since 17.10.10
     */
    public string directory;

    /**
     * Load clips.
     *
     * @since 17.10.10
     */
    void Awake()
    {
        //load all the music in the folder specified in parameter\\
        music = Resources.LoadAll(directory, typeof(AudioClip));
        GetComponent<AudioSource>().clip = music[0] as AudioClip;
    }

    /**
     * Play clips.
     *
     * @since 17.10.10
     */
    void Start ()
    {
        GetComponent<AudioSource>().Play();	
	}

    /**
     * Play clips.
     *
     * @since 17.10.10
     */
	void Update ()
    {
		if (!GetComponent<AudioSource>().isPlaying)
        {
            playRandomClip();
        }
	}

    /**
     * Play random clip.
     *
     * @since 17.10.10
     */
    void playRandomClip ()
    {
        GetComponent<AudioSource>().clip = music[Random.Range(0, music.Length)] as AudioClip;
        GetComponent<AudioSource>().Play();
    }
}
