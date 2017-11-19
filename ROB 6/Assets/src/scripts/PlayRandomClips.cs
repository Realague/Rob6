using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * PlayRandomClips.
 *
 * @author Julien Delane
 * @version 17.11.19
 * @since 17.10.10
 */
public class playRandomClips : MonoBehaviour
{
    /**
     * List of clips.
     *
     * @since 17.10.10
     */
    private Object[] clipsList;

    /**
     * Directory where are soundtracks.
     *
     * @unityParam
     * @since 17.10.10
     */
     [SerializeField]
    private string directory;

    /**
     * Load clips.
     *
     * @since 17.10.10
     */
    private void Awake()
    {
        //load all the music in the folder specified in parameter\\
        clipsList = Resources.LoadAll(directory, typeof(AudioClip));
        GetComponent<AudioSource>().clip = clipsList[0] as AudioClip;
    }

    /**
     * Start to play clips.
     *
     * @since 17.10.10
     */
    private void Start()
    {
        GetComponent<AudioSource>().Play();	
	}

    /**
     * Play clips.
     *
     * @since 17.10.10
     */
	private void Update()
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
    private void playRandomClip()
    {
        GetComponent<AudioSource>().clip = clipsList[Random.Range(0, clipsList.Length)] as AudioClip;
        GetComponent<AudioSource>().Play();
    }
}
