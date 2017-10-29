using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * OpenClose.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.26
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

    /**
     * The temp timer.
     *
     * @since 17.10.10
     */
    private float tempTimer;

    /**
     * Gate position.
     *
     * @since 17.10.10
     */
    private Vector2 gatePosition;

    /**
     * If nbOpen equals 1 the gate will open one time else it can be open/close as many time as you want.
     * nb open equals 1 if openOnce is true
     *
     * @since 17.10.10
     */
    private int nbTimesOpen = 2;

    /**
     * Clip to play when the object move.
     *
     * @unityParam
     * @since 17.10.10
     */
    public AudioClip clip;

    /**
     * If true the player can only interact with the button one time.
     *
     * @unityParam
     * @since 17.10.10
     */
    public bool openOnce = false;

    /**
     * Distance of the movement of the game object.
     * If < 0 will close then open the gate otherwise it will open then close
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
    public Text protectionText;

    /**
     * Init the gate position.
     *
     * @since 17.10.10
     */
    protected void Start()
    {
        gatePosition.x = gate.transform.position.x;
        gatePosition.y = gate.transform.position.y;
        distance = -distance;
        protectionText.enabled = false;
    }

    /**
     * Try to open the gate and play the animation.
     *
     * @since 17.10.10
     */
    protected void Update()
    {
        button = Input.GetKeyDown(KeyCode.E);
        if (button && canInteract && tempTimer <= 0 && nbTimesOpen != 0)
        {
            if (protection == true && PlayerManager.current.name.CompareTo("Rob.H") != 0)
            {
                StartCoroutine(protectedMessage());
            }
            else
            {
                distance = -distance;
                tempTimer = timer;
                button = false;
                gatePosition.y = gate.transform.position.y;
                AudioSource.PlayClipAtPoint(clip, gate.transform.position);
            }
        }
        //move the object
        if (tempTimer > 0)
        {
            gate.transform.position = new Vector2(gatePosition.x, gatePosition.y - (distance * (tempTimer - timer) / timer));
            //if we need to interact only one time
            if (openOnce)
            {
                nbTimesOpen = 0;
            }
            tempTimer = tempTimer - Time.deltaTime;
        }
    }

    /**
     * Display the protected text for 1 seconds.
     *
     * @since 17.10.26
     */
    public IEnumerator protectedMessage()
    {
        protectionText.enabled = true;
        yield return new WaitForSecondsRealtime(1);
        protectionText.enabled = false;
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
        if (collider.name == PlayerManager.current.name)
        {
            canInteract = false;
        }
    }

}

