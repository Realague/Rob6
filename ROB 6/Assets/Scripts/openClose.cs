using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * OpenClose.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.11
 * @since 17.10.10
 */
public class openClose : MonoBehaviour {

    /**
     * If the button is pressed.
     *
     * @since 17.10.10
     */
    private bool button = false;

    /**
     * If the player is in the button area.
     *
     * @since 17.10.10
     */
    private bool col = false;

    //TODO: move the variable
    private float temp_timer;

    /**
     * Gate position.
     *
     * @since 17.10.10
     */
    private Vector2 pos_door;

    /**
     * If nb_open equals 1 the gate will open one time else it can be open/close as many time as you want.
     * nb open equals 1 if openOnce is true
     *
     * @since 17.10.10
     */
    private int nb_open = 2;

    /**
     * Sound to play when the object move.
     *
     * @unityParam
     * @since 17.10.10
     */
    public AudioClip sound;

    /**
     * If true the player can only interact with the button one time.
     *
     * @unityParam
     * @since 17.10.10
     */
    public bool open_once = false;

    /**
     * Distance of the movement of the game object.
     * If minus 0 will close then open the door otherwise it will open then close
     *
     * @unityParam
     * @since 17.10.10
     */
    public float distance = 1f;

    /**
     * Define the time to travel the distance.
     *
     * @unityParam
     * @since 17.10.10
     */
    public float timer = 1.5f;

    /**
     * Game object to move.
     *
     * @unityParam
     * @since 17.10.10
     */
    public GameObject door;

    /**
     * Define which rob can open the gate.
     *
     * @unityParam
     * @since 17.10.10
     */
    public bool protection;

    /**
     * The text to display if we can't open the gate.
     *
     * @unityParam
     * @since 17.10.10
     */
    public Text Protected;

    /**
     * Timer if the gate is protected.
     *
     * @since 17.10.10
     */
    private float timer2;

    /**
     * The text to display if we can't open the gate.
     *
     * @since 17.10.10
     */
    private float speed = 5f;

    private float test;

    /**
     * Init the door position.
     *
     * @since 17.10.10
     */
    private void Start()
    {
        if (open_once)
            nb_open = 1;
        pos_door.x = door.transform.position.x;
        pos_door.y = door.transform.position.y;
        distance = -distance;
        Protected.enabled = false;
    }

    /**
     * Try to open the gate and play the animation.
     *
     * @since 17.10.10
     */
    void Update()
    {
        //catch if the button e is pressed and then initialise some value
        button = Input.GetKeyDown(KeyCode.E);
        if (button && col && temp_timer <= 0 && (nb_open == 2 || nb_open == 1))
        {
            if (protection == true && cursor.current.name != "Rob.H")
            {
                Protected.enabled = true;
                
            }
            else
            {
                distance = -distance;
                temp_timer = timer;
                button = false;
                pos_door.y = door.transform.position.y;
                Protected.enabled = false;
            }
        }
       if (Protected.enabled == true && timer2 <= Time.time)
        {
            Protected.enabled = false;
        }
       else if (timer2 <= Time.time)
            timer2 = Time.time + speed;
        //play the sound
        if (temp_timer == timer)
            AudioSource.PlayClipAtPoint(sound, door.transform.position);
        //move the object
        if (temp_timer > 0)
            {
                door.transform.position = new Vector2(pos_door.x, pos_door.y - (distance * (temp_timer - timer) / timer));
                //if we need to interact once
                if (nb_open == 1)
                    nb_open = 0;
            }
        temp_timer = temp_timer - Time.deltaTime;
    }

    /**
     * Check if the player is in the button area.
     *
     * @param collider object which enter in the button area
     * @since 17.10.10
     */
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == cursor.current.name)
            col = true;
        else
            col = false;
    }

    /**
     * Check if the player exit the button area.
     *
     * @param collider object which enter in the button area
     * @since 17.10.10
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == cursor.current.name)
            col = false;
    }
}

