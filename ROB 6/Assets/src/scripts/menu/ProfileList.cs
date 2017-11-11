using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * ProfileList.
 *
 * @author Julien Delane
 * @version 17.11.11
 * @since 17.11.04
 */
public class ProfileList : MonoBehaviour
{
	/**
	 * The profile prefab.
	 *
	 * @unityParam
	 * @since 17.11.05
	 */
	public GameObject profilePrefab;

	/**
	 * Transform parent.
	 *
	 * @unityParam
	 * @since 17.11.05
	 */
	public Transform profileParent;

    /**
     * The button clip.
     *
	 * @unityParam
     * @since 17.11.05
     */
    public AudioClip buttonClip;

    /**
     * The switch clip.
     *
	 * @unityParam
     * @since 17.11.05
     */
    public AudioClip switchClip;

    /**
     * The index of the cursor.
     *
     * @since 17.11.05
     */
    private int i = 0;

    /**
     * The cursor.
     *
     * @unityParam
     * @since 17.11.05
     */
    public GameObject cursor;

	/**
     * The profile list.
     *
     * @since 17.11.05
     */
    private List<Profile> profiles;

    /**
     * The game objects.
     *
     * @since 17.11.08
     */
    private List<GameObject> profileObjects;

    /**
     * Index down.
     *
     * @since 17.11.08
     */
    private int indexDown = 0;

    /**
     * Offset between index.
     *
     * @since 17.11.05
     */
    private float offset = -30;

	/**
	 * Init the profile UI.
	 *
	 * @since 17.11.05
	 */
	private void Start()
	{
        profileObjects = new List<GameObject> ();
		profiles = Profile.getAllProfile();
		showProfiles();
	}
	
    /**
     * Check if the key to move the cursor position are pressed then call the method to move the cursor and call the select method.
     *
     * @since 17.11.05
     */
	private void Update()
	{
		if (Input.GetKeyDown("z"))
        {
            AudioSource.PlayClipAtPoint(switchClip, transform.position);
            if (indexDown != 0 && i == 0)
            {
                indexDown--;
                for (int x = 0; x + indexDown < profiles.Count && x < 12; x++)
                {
                    Profile profile = profiles[x + indexDown];
			        profileObjects[x].GetComponent<ProfileCell>().setProfile(profile.Name, profile.LastUpdateDate, profile.CreationDate, profile.TimeSpend);
                }
            }
            else if (i != 0)
            {
                i--;
            }
            cursor.transform.position = new Vector2(cursor.transform.position.x, profileObjects[i].transform.position.y + offset);
        }
        else if (Input.GetKeyDown("s"))
        {
            AudioSource.PlayClipAtPoint(switchClip, transform.position);
            if (i == 11 && indexDown + 11 != profiles.Count - 1)
            {
                indexDown++;
                for (int x = 0; x + indexDown < profiles.Count && x < 12; x++)
                {
                    Profile profile = profiles[x + indexDown];
			        profileObjects[x].GetComponent<ProfileCell>().setProfile(profile.Name, profile.LastUpdateDate, profile.CreationDate, profile.TimeSpend);
                }
            }
            else if (i != 11 && indexDown + i != profiles.Count - 1)
            {
                ++i;
            }
            cursor.transform.position = new Vector2(cursor.transform.position.x, profileObjects[i].transform.position.y + offset);
        }
        StartCoroutine(select());
	}

	/**
     * Check if the player select a profile and launch it.
     *
     * @since 17.11.05
     */
    private IEnumerator select()
    {
        if (Input.GetKeyDown("space"))
        {
            AudioSource.PlayClipAtPoint(buttonClip, transform.position);
            yield return new WaitForSecondsRealtime(buttonClip.length);
			SceneManager.LoadScene(profiles[i].LevelId);
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            AudioSource.PlayClipAtPoint(buttonClip, transform.position);
            yield return new WaitForSecondsRealtime(buttonClip.length);
            Profile.deleteProfile(profiles[i].Id);
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioSource.PlayClipAtPoint(buttonClip, transform.position);
            yield return new WaitForSecondsRealtime(buttonClip.length);
            SceneManager.LoadScene(0);
        }
    }

	/**
	 * Show profile.
	 *
	 * @since 17.11.05
	 */
	private void showProfiles()
	{
		for (int i = 0; i < profiles.Count && i < 12; i++)
		{
			GameObject profileObject = Instantiate(profilePrefab);
			Profile profile = profiles[i];
			profileObject.GetComponent<ProfileCell>().setProfile(profile.Name, profile.LastUpdateDate, profile.CreationDate, profile.TimeSpend);
			profileObject.transform.SetParent(profileParent);
			profileObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            profileObjects.Add(profileObject);
		}
	}

}