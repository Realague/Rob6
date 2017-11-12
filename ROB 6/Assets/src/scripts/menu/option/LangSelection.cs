using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * LangSelection.
 *
 * @author Julien Delane
 * @version 17.11.12
 * @since 17.11.10
 */
public class LangSelection : MonoBehaviour
{
    /**
     * Nb row.
     *
     * @since 17.11.11
     */
    private int nbRow = 12;

	/**
	 * The lang prefab.
	 *
	 * @unityParam
	 * @since 17.11.10
	 */
	public GameObject langPrefab;

	/**
	 * Transform parent.
	 *
	 * @unityParam
	 * @since 17.11.10
	 */
	public Transform langParent;

    /**
     * The index of the cursor.
     *
     * @since 17.11.10
     */
    private int i = 0;

    /**
     * The cursor.
     *
     * @unityParam
     * @since 17.11.11
     */
    public GameObject cursor;

	/**
     * The lang list.
     *
     * @since 17.11.10
     */
    private List<Lang> langs;

    /**
     * The game objects.
     *
     * @since 17.11.10
     */
    private List<GameObject> langObjects;

    /**
     * Index down.
     *
     * @since 17.11.10
     */
    private int indexDown = 0;

    /**
     * Offset between index.
     *
     * @since 17.11.10
     */
    private float offset = -40;

	/**
	 * Init the profile UI.
	 *
	 * @since 17.11.10
	 */
	private void Start()
	{
        langObjects = new List<GameObject> ();
		langs = Lang.getLangFile();
		showLangs();
        if (langObjects.Count == 0)
        {
            Destroy(cursor);
        }
	}
	
    /**
     * Check if the key to move the cursor position are pressed then call
	 * the method to move the cursor and call the select method.
     *
     * @since 17.11.10
     */
	private void Update()
	{
		if (Input.GetKeyDown("z"))
        {
            AudioSource.PlayClipAtPoint(ProfileScript.instance.switchClip, transform.position);
            if (indexDown != 0 && i == 0)
            {
                indexDown--;
                for (int x = 0; x + indexDown < langs.Count && x < nbRow; x++)
                {
			        langObjects[x].GetComponent<LangCell>().setLang(langs[x].Name);
                }
            }
            else if (i != 0)
            {
                i--;
            }
            cursor.transform.position = new Vector2(cursor.transform.position.x, langObjects[i].transform.position.y + offset);
        }
        else if (Input.GetKeyDown("s"))
        {
            AudioSource.PlayClipAtPoint(ProfileScript.instance.switchClip, transform.position);
            if (i == nbRow - 1 && indexDown + nbRow - 1 != langs.Count - 1)
            {
                indexDown++;
                for (int x = 0; x + indexDown < langs.Count && x < nbRow; x++)
                {
			        langObjects[x].GetComponent<LangCell>().setLang(langs[x].Name);
                }
            }
            else if (i != nbRow - 1 && indexDown + i != langs.Count - 1)
            {
                ++i;
            }
            cursor.transform.position = new Vector2(cursor.transform.position.x, langObjects[i].transform.position.y + offset);
        }
        StartCoroutine(select());
	}

	/**
     * Check if the player select a lang load it and come back to main menu.
     *
     * @since 17.11.10
     */
    private IEnumerator select()
    {
        if (Input.GetKeyDown("space"))
        {
            AudioSource.PlayClipAtPoint(ProfileScript.instance.buttonClip, transform.position);
            yield return new WaitForSecondsRealtime(ProfileScript.instance.buttonClip.length);
            langs[i + indexDown].selectLanguage();
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKeyDown("escape"))
        {
            AudioSource.PlayClipAtPoint(ProfileScript.instance.buttonClip, transform.position);
            yield return new WaitForSecondsRealtime(ProfileScript.instance.buttonClip.length);
            SceneManager.LoadScene(3);
        }
    }

	/**
	 * Show langs.
	 *
	 * @since 17.11.10
	 */
	private void showLangs()
	{
		for (int i = 0; i < langs.Count && i < nbRow; i++)
		{
			GameObject langObject = Instantiate(langPrefab);
			langObject.GetComponent<LangCell>().setLang(langs[i].Name);
			langObject.transform.SetParent(langParent);
			langObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            langObjects.Add(langObject);
		}
	}

}
