using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * CreationMenu.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.11
 * @since 17.10.05
 */
public class creationMenu : MonoBehaviour {

    /**
     * Menu canvas.
     *
     * @since 17.10.10
     */
    private Canvas can;

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
     * Index of the cursor.
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
     * Rob where he will be create.
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
	void Start () {
        can = GetComponent<Canvas>();
        can.enabled = false;
        images = GetComponentsInChildren<Image>();
        images[1].sprite = create[0].GetComponentInChildren<SpriteRenderer>().sprite;
        images[2].sprite = create[1].GetComponentInChildren<SpriteRenderer>().sprite;
    }
	
	/**
     * Manage the creation menu (cursor and selection of object).
     *
     * @since 17.10.05
     */
	void Update() { 
         if (can.enabled == true)
        {
            playerController.stop = true;
        }
        else
        {
            playerController.stop = false;
        }
        if (cursor.current.name == "Rob.I" && Input.GetKeyDown("e") && can.enabled == false)
        {
            can.enabled = true;
        }
        else if (cursor.current.name == "Rob.I" && Input.GetKeyDown("e") && can.enabled == true)
        {
            can.enabled = false;
        }
        if (can.enabled == true)
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
            if (Input.GetKeyDown("f") && cursor.inventory[cursor.current.name] != null && cursor.inventory[cursor.current.name].Count >= price[index])
            {
                Instantiate(create[index], spawnPoint.transform.position, spawnPoint.transform.rotation);
                can.enabled = false;
                cursor.inventory[cursor.current.name].RemoveRange(cursor.inventory[cursor.current.name].Count - price[index], price[index]);
            }
        }
	}
}

