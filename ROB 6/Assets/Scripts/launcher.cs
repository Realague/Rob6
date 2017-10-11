using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Launcher.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.11
 * @since 17.10.10
 */
public class launcher : MonoBehaviour {

    /**
     * The spawn point.
     *
     * @unityParam
     * @since 17.10.10
     */
    public GameObject spawn;

    /**
     * The object to render when launch.
     *
     * @since 17.10.10
     */
    private SpriteRenderer sprite;

    /**
     * The sprite of the launch rob.
     *
     * @since 17.10.10
     */
    private SpriteRenderer spriteRob;

    /**
     * The list of robs.
     *
     * @unityParam
     * @since 17.10.10
     */
    public GameObject[] Robs;

    /**
     * Init the object sprite and the sprite of rob.
     *
     * @since 17.10.10
     */
	void Start () {
        sprite = GetComponentInChildren<SpriteRenderer>();
        spriteRob = GetComponentInParent<SpriteRenderer>();
    }
	
    /**
     * Get the object and launch it.
     *
     * @since 17.10.10
     */
	void Update () {
        if (sprite.sortingOrder < spriteRob.sortingOrder)
            sprite.sortingOrder = spriteRob.sortingOrder + 1;
        if (cursor.current.name == "Rob.L")
        {
            if (Input.GetKeyDown("z") && ((cursor.current.transform.localScale.x > 0 && transform.rotation.z < 0.4) 
                                        || (cursor.current.transform.localScale.x < 0 && transform.rotation.z > -0.4)))
            {
                transform.Rotate(new Vector3(0, 0, 15));
            }
            else if (Input.GetKeyDown("s") && ((transform.rotation.z > -0.4 && cursor.current.transform.localScale.x > 0) 
                                            || (cursor.current.transform.localScale.x < 0 && transform.rotation.z < 0.4)))
            {
                transform.Rotate(new Vector3(0, 0, -15));
            }
            else if (Input.GetKeyDown("e"))
            {
                GameObject sc = null;
                if (playerController.fly != null)
                {
                    sc = playerController.fly;
                    playerController.fly = null;
                }
                else if (cursor.inventory[cursor.current.name] != null)
                {

                    GameObject[] scraps = cursor.inventory[cursor.current.name].ToArray();
                    sc = scraps[scraps.Length - 1];
                    cursor.inventory[cursor.current.name].Remove(scraps[scraps.Length - 1]);
                    if (scraps.Length - 2 < 0)
                        cursor.inventory[cursor.current.name] = null;
                }
                if (sc != null)
                {
                    sc.SetActive(true);
                    sc.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y);
                    sc.GetComponent<Rigidbody2D>().AddForce(spawn.transform.forward * 50, ForceMode2D.Impulse);
                    if (sc.tag != "scrap")
                        foreach (GameObject rob in Robs)
                         {    
                            Physics2D.IgnoreCollision(sc.GetComponent<Collider2D>(), rob.GetComponent<Collider2D>(), true);
                        }
                }  
            }
        }
    }
}
