using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Launcher.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.11.19
 * @since 17.10.10
 */
public class Launcher : MonoBehaviour
{
    /**
     * The list of robs.
     *
     * @unityParam
     * @since 17.10.10
     */
    [SerializeField]
    private GameObject[] Robs;
    
    /**
     * The spawn point.
     *
     * @unityParam
     * @since 17.10.10
     */
    [SerializeField]
    private GameObject spawn;

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
     * Init the object sprite and the sprite of rob.
     *
     * @since 17.10.10
     */
	private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        spriteRob = GetComponentInParent<SpriteRenderer>();
    }
	
    /**
     * Get the object and launch it.
     *
     * @since 17.10.10
     */
	private void Update()
    {
        if (sprite.sortingOrder < spriteRob.sortingOrder)
        {
            sprite.sortingOrder = spriteRob.sortingOrder + 1;
        }
        if (PlayerManager.current.name.CompareTo("Rob.L") == 0)
        {
            if (Input.GetKeyDown("z") && ((PlayerManager.current.transform.localScale.x > 0 && transform.rotation.z < 0.4) 
                                        || (PlayerManager.current.transform.localScale.x < 0 && transform.rotation.z > -0.4)))
            {
                transform.Rotate(new Vector3(0, 0, 15));
            }
            else if (Input.GetKeyDown("s") && ((transform.rotation.z > -0.4 && PlayerManager.current.transform.localScale.x > 0) 
                                            || (PlayerManager.current.transform.localScale.x < 0 && transform.rotation.z < 0.4)))
            {
                transform.Rotate(new Vector3(0, 0, -15));
            }
            else if (Input.GetKeyDown("e"))
            {
                GameObject sc = null;
                if (PlayerController.fly != null)
                {
                    sc = PlayerController.fly;
                    PlayerController.fly = null;
                }
                else if (PlayerManager.inventory[PlayerManager.current.name] != null)
                {
                    GameObject[] scraps = PlayerManager.inventory[PlayerManager.current.name].ToArray();
                    sc = scraps[scraps.Length - 1];
                    PlayerManager.inventory[PlayerManager.current.name].Remove(scraps[scraps.Length - 1]);
                    if (scraps.Length - 2 < 0)
                    {
                        PlayerManager.inventory[PlayerManager.current.name] = null;
                    }
                }
                if (sc != null)
                {
                    sc.SetActive(true);
                    sc.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y);
                    sc.GetComponent<Rigidbody2D>().AddForce(spawn.transform.forward * 50, ForceMode2D.Impulse);
                    if (sc.tag.CompareTo("scrap") != 0)
                    {
                        foreach (GameObject rob in Robs)
                        {    
                            Physics2D.IgnoreCollision(sc.GetComponent<Collider2D>(), rob.GetComponent<Collider2D>(), true);
                        }
                    }
                }
            }
        }
    }

}
