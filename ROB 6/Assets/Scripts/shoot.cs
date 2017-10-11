using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Shoot.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.11
 * @since 17.10.11
 */
public class shoot : MonoBehaviour {

    /**
     * Speed of bullets.
     *
     * @since 17.10.11
     */
    public float speed = 100.0f;

    /**
     * Positions of the bullet.
     *
     * @since 17.10.11
     */
    public GameObject my_position;

    /**
     * Move the bullet.
     *
     * @since 17.10.11
     */
	void Update ()
    {
        my_position.transform.Translate(Vector2.left * (Time.deltaTime * speed));
        Destroy(this.gameObject, 3.0f);
    }
}
