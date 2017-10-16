using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * EnableCollider.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.16
 * @since 17.10.05
 */
public class EnableCollider : MonoBehaviour
{
    /**
     * The collide area.
     *
     * @since 17.10.05
     */
    private EdgeCollider2D edgeCollider;

    /**
     * Get the collide area.
     *
     * @since 17.10.05
     */
    private void Start()
    {
         edgeCollider = GetComponentInParent<EdgeCollider2D>();
         edgeCollider.enabled = false;
    }

    /**
     * Check if a rob enter in the area collider and enable collision.
     *
     * @param collider area to check if rob get in
     * @since 17.10.05
     */
	private void OnTriggerEnter2D(Collider2D collider)
    {
       if (collider.tag == "Rob")
        {
            edgeCollider.enabled = true;
        }
    }

    /**
     * Check if a rob exit the area collider and disable collision.
     *
     * @param collider area to check if rob get out
     * @since 17.10.05
     */
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Rob")
        {
            edgeCollider.enabled = false;
        }
    }

}
