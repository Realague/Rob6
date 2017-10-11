using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * EnableCollider.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.11
 * @since 17.10.05
 */
public class enableCollider : MonoBehaviour {

    /**
     * The collide area.
     *
     * @since 17.10.05
     */
    private EdgeCollider2D colli;

    /**
     * Get the collide area.
     *
     * @since 17.10.05
     */
    void Start()
    {
         colli = GetComponentInParent<EdgeCollider2D>();
         colli.enabled = false;
    }

    /**
     * Check if a rob enter in the area collider and enable collision.
     *
     * @param collider area to check if rob get in
     * @since 17.10.05
     */
	void OnTriggerEnter2D(Collider2D coll)
    {
       if (coll.tag == "Rob")
        {
            colli.enabled = true;
        }
    }

    /**
     * Check if a rob exit the area collider and disable collision.
     *
     * @param collider area to check if rob get out
     * @since 17.10.05
     */
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Rob")
        {
            colli.enabled = false;
        }
    }
}
