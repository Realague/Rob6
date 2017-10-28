using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * CreationMenu.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.15
 * @since 17.10.05
 */
public class CreationMenu : MonoBehaviour
{
    /**
     * Menu canvas.
     *
     * @since 17.10.10
     */
    private Canvas canvas;

    /**
     * GameObject selected.
     *
     * @unityParam
     * @since 17.10.10
     */
    public GameObject select;

    /**
     * List of GameObject player can create.
     *
     * @unityParam
     * @since 17.10.10
     */
    public GameObject[] create;

    /**
     * List of price to create object.
     *
     * @unityParam
     * @since 17.10.10
     */
    public int[] price;

    /**
     * Index of the Cursor.
     *
     * @since 17.10.10
     */
    private int index = 0;

    /**
     * List of object image.
     *
     * @since 17.10.10
     */
    private Image[] images;

    /**
     * Rob where object will be created.
     *
     * @unityParam
     * @since 17.10.10
     */
    public GameObject spawnPoint;
    
    /**
     * Initialize the camera and sprites for the image.
     * 
     * @since 17.10.05
     */
	private void Start () {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        images = GetComponentsInChildren<Image>();
        images[1].sprite = create[0].GetComponentInChildren<SpriteRenderer>().sprite;
        images[2].sprite = create[1].GetComponentInChildren<SpriteRenderer>().sprite;
    }
	
	/**
     * Manage the creation menu (cursor and selection of object).
     *
     * @since 17.10.05
     */
	private void Update() { 
         if (canvas.enabled == true)
        {
            PlayerController.stop = true;
        }
        else
        {
            PlayerController.stop = false;
        }
        if (PlayerManager.current.name.CompareTo("Rob.I") == 1 && Input.GetKeyDown("e") && canvas.enabled == false)
        {
            canvas.enabled = true;
        }
        else if (PlayerManager.current.name.CompareTo("Rob.I") == 1 && Input.GetKeyDown("e") && canvas.enabled == true)
        {
            canvas.enabled = false;
        }
        if (canvas.enabled == true)
        {
            if (Input.GetKeyDown("d") && index != create.Length - 1)
            {
                select.GetComponent<Image>().transform.Translate(new Vector2(600, 0));
                index++;
            }
            if (Input.GetKeyDown("q") && index != 0)
            {
                select.GetComponent<Image>().transform.Translate(new Vector2(-600, 0));
                index--;
            }
            if (Input.GetKeyDown("f") && PlayerManager.inventory[PlayerManager.current.name] != null && PlayerManager.inventory[PlayerManager.current.name].Count >= price[index])
            {
                Instantiate(create[index], spawnPoint.transform.position, spawnPoint.transform.rotation);
                canvas.enabled = false;
                PlayerManager.inventory[PlayerManager.current.name].RemoveRange(PlayerManager.inventory[PlayerManager.current.name].Count - price[index], price[index]);
            }
        }
	}

}

