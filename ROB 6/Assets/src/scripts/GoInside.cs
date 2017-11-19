using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * GoInside
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.26
 * @since 17.10.05
 */
public class GoInside : MonoBehaviour
{
    /**
     * Put the layer to 12 to change the brightness when the player enter in the area.
     *
     * @param collider the area
     * @since 17.10.05
     */
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer != 12)
        {
            collider.gameObject.layer = 12;
        }
    }

    /**
     * Put the layer to 12 to change the brightness when the player stay in the area.
     *
     * @param collider the area
     * @since 17.10.05
     */
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer != 12)
        {
            collider.gameObject.layer = 12;
        }
    }

    /**
     * Put the layer to 13 to change the brightness when the player exit the area.
     *
     * @param collider the area
     * @since 17.10.05
     */
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer != 13)
        {
            collider.gameObject.layer = 13;
        }
    }
}
