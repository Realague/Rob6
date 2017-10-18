using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * OpenClose.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.15
 * @since 17.10.10
 */
public class OpenClose : MonoBehaviour
{
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
    private bool canInteract = false;

    //TODO: move the variable
    private float tempTimer;

    /**
     * Gate position.
     *
     * @since 17.10.10
     */
    private Vector2 gatePosition;

    /**
     * If nb_open equals 1 the gate will open one time else it can be open/close as many time as you want.
     * nb open equals 1 if openOnce is true
     *
     * @since 17.10.10
     */
    private int nbTimesOpen = 2;

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
    public bool openOnce = false;

    /**
     * Distance of the movement of the game object.
     * If minus 0 will close then open the gate otherwise it will open then close
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
    public GameObject gate;

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
    public Text protect;

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
     * Init the gate position.
     *
     * @since 17.10.10
     */
    private void Start()
    {
        if (openOnce)
        {
            nbTimesOpen = 1;
        }
        gatePosition.x = gate.transform.position.x;
        gatePosition.y = gate.transform.position.y;
        distance = -distance;
        protect.enabled = false;
    }

    /**
     * Try to open the gate and play the animation.
     *
     * @since 17.10.10
     */
    private void Update()
    {
        //catch if the button e is pressed and then initialise some value
        button = Input.GetKeyDown(KeyCode.E);
        if (button && canInteract && tempTimer <= 0 && (nbTimesOpen == 2 || nbTimesOpen == 1))
        {
            if (protection == true && PlayerManager.current.name != "Rob.H")
            {
                protect.enabled = true;
                
            }
            else
            {
                distance = -distance;
                tempTimer = timer;
                button = false;
                gatePosition.y = gate.transform.position.y;
                protect.enabled = false;
            }
        }
       if (protect.enabled == true && timer2 <= Time.time)
        {
            protect.enabled = false;
        }
       else if (timer2 <= Time.time)
            timer2 = Time.time + speed;
        //play the sound
        if (tempTimer == timer)
            AudioSource.PlayClipAtPoint(sound, gate.transform.position);
        //move the object
        if (tempTimer > 0)
            {
                gate.transform.position = new Vector2(gatePosition.x, gatePosition.y - (distance * (tempTimer - timer) / timer));
                //if we need to interact once
                if (nbTimesOpen == 1)
                    nbTimesOpen = 0;
            }
        tempTimer = tempTimer - Time.deltaTime;
    }

    /**
     * Check if the player is in the button area.
     *
     * @param collider object which enter in the button area
     * @since 17.10.10
     */
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.name == PlayerManager.current.name)
        {
            canInteract = true;
        }
        else
        {
            canInteract = false;
        }
    }

    /**
     * Check if the player exit the button area.
     *
     * @param collider object which enter in the button area
     * @since 17.10.10
     */
    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.name == PlayerManager.current.name)
        {
            canInteract = false;
        }
    }

}

