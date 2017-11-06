using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * PlayerManager.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.23
 * @since 17.10.05
 */
 //TODO: rework the player manager inventory in this script??
public class PlayerManager : MonoBehaviour
{
    /**
     * The object spawn.
     *
     * @since 17.10.05
     */
    public GameObject spawn;

    /**
     * Current rob.
     *
     * @since 17.10.05
     */
    public static GameObject current;

    /**
     * The list of rob.
     *
     * @since 17.10.05
     */
    public GameObject[] players;

    /**
     * The list of sprite.
     *
     * @since 17.10.05
     */
    private SpriteRenderer[] signals;

    /**
     * The signal sprite.
     *
     * @since 17.10.05
     */
    public static SpriteRenderer stock;

    /**
     * Timer for the flash.
     *
     * @since 17.10.05
     */
    private float timer;

    /**
     * Speed of the trail.
     *
     * @since 17.10.05
     */
    private float speed = 2f;

    /**
     * The alpha of the trail.
     *
     * @since 17.10.05
     */
    private float alpha = 1;

    /**
     * Define if the signal will be more visible or not.
     *
     * @since 17.10.05
     */
    private bool positive = false;

    /**
     * playersList.
     *
     * @since 17.10.05
     */
    public static GameObject[] playersList;

    /**
     * Map which contain inventory of all rob every case contains a list of game object which is the individual inventory of the rob,
     * keys are the name of the rob.
     *
     * @since 17.10.05
     */
     //TODO: create an object instead and put it in player object
    public static Dictionary<string, List<GameObject>> inventory = null;

    /**
     * Set the cursor to invisible, initialize the starting rob,
     * disable the "no signal" logo and allow to ignore collision between rob and init the inventory.
     *
     * @since 17.10.05
     */
    private void Start()
    {
        playersList = players;
        inventory = new Dictionary<string, List<GameObject>>();
        Cursor.visible = false;
        current = spawn;
        if (current.transform.name == "Rob.I" || current.transform.name == "Rob.B" || current.transform.name == "Rob.6")
        {
            PlayerController.anim = current.GetComponent<Animator>();
        }
        foreach (GameObject player1 in players)
        {
            List<GameObject> scrap = null;
            inventory.Add(player1.name, scrap);
            signals = player1.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sprite in signals)
            {
                if (sprite.tag == "signal")
                {
                    sprite.enabled = false;
                }
            }
            foreach (GameObject player2 in players)
            {
               Physics2D.IgnoreCollision(player1.GetComponent<Collider2D>(), player2.GetComponent<Collider2D>(), true);
            }
        }
	}
	
    /**
     * Manage character change, fix the layers problem and set a limited distance.
     *
     * @since 17.10.05
     */
	private void Update()
    {
        int layer;
        float closer = 100;
        GameObject collider = null;

        if (Input.GetKeyDown(KeyCode.LeftShift) && PlayerController.stop == false)
        {
            foreach (GameObject player in players)
            {
                if (closer > Vector3.Distance(current.transform.position, player.transform.position) && player.name != current.name && 
                    (PlayerController.fly == null || (PlayerController.fly != null && PlayerController.fly.name != player.name)))
                {
                    closer = Vector3.Distance(current.transform.position, player.transform.position);
                    collider = player;
                }
            }

            if (closer <= 18f && collider != null)
            {
                if (stock != null)
                {
                    stock.enabled = false;
                }
                layer = current.GetComponent<SpriteRenderer>().sortingOrder;
                current.GetComponent<SpriteRenderer>().sortingOrder = collider.GetComponent<SpriteRenderer>().sortingOrder;
                collider.GetComponent<SpriteRenderer>().sortingOrder = layer;
                current.GetComponent<PlayerController>().enabled = false;
                if (current.transform.name == "Rob.I" || current.transform.name == "Rob.B")
                {
                    PlayerController.anim.SetBool("run", false);
                }
                current = collider.gameObject;
                current.GetComponent<PlayerController>().enabled = true;
                if (current.transform.name == "Rob.I" || current.transform.name == "Rob.B")
                {
                    PlayerController.anim = current.GetComponent<Animator>();
                }
            }
            else
            {
                signals = current.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer sprite in signals)
                {
                    if (sprite.tag == "signal")
                    {
                        timer = Time.time + speed;
                        stock = sprite;
                        stock.enabled = true;
                    }
                }
            }
        }
        flash();
    }

    /**
     * Make the signal sprite flash.
     *
     * @since 17.10.05
     */
    private void flash()
    {
        if (timer > Time.time)
        { 
            stock.color = new Color(1, 1, 1, alpha);
            if (alpha <= 0)
            {
                positive = true;
            }
            else if (alpha >= 1)
            {
                positive = false;
            }
            if (positive == false)
            {
                alpha -= 0.1f;
            }
            else
            {
                alpha += 0.1f;
            }
        }
        else if (stock != null)
        {
            stock.color = new Color(1, 1, 1, 1);
            stock.enabled = false;
        }
    }

}
