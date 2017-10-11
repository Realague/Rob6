using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Up.
 * Open the game object he is link
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.11
 * @since 17.10.11
 */
public class up : MonoBehaviour {

    /**
     * Init animator.
     *
     * @since 17.10.11
     */
    private bool go = false;

    /**
     * Time to move the game object.
     *
     * @since 17.10.11
     */
    private float timer;

    /**
     * Define if the game object move automatically when the player is near it.
     *
     * @unityParam
     * @since 17.10.11
     */
    public bool auto;

    /**
     * Speed of the object.
     *
     * @since 17.10.11
     */
    private float speed = 0.001f;

    /**
     * Init the time for the object to move.
     *
     * @since 17.10.11
     */
	void Start () {
        timer = Time.time + speed;
	}
	
    /**
     * Move the object.
     *
     * @since 17.10.11
     */
	void Update () {
        if (auto == true)
            go = true;
       if (go == true && timer <= Time.time && (transform.position.y < 0f || auto == false))
        {
            transform.Translate(new Vector3(0, 0.1f));
            timer = Time.time + speed;
        }
	}

    /**
     * Get if the player press the action key when he is in the area.
     *
     * @param collider area
     * @since 17.10.11
     */
    void OnCollisionStay2D(Collision2D coll)
    {
        if (Input.GetKey("e"))
        {
            go = true;
            timer = Time.time + speed;
        }
    }
}
