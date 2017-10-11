using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * GoInside
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.10
 * @since 17.10.05
 */
public class goInside : MonoBehaviour {

    /**
     * Put the layer to 12 to change the brightness when the player enter in the area.
     *
     * @param coll the area
     * @since 17.10.05
     */
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer != 12)
            coll.gameObject.layer = 12;
    }

    /**
     * Put the layer to 12 to change the brightness when the player stay in the area.
     *
     * @param coll the area
     * @since 17.10.05
     */
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.layer != 12)
            coll.gameObject.layer = 12;
    }

    /**
     * Put the layer to 13 to change the brightness when the player exit the area.
     *
     * @param coll the area
     * @since 17.10.05
     */
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.layer != 13)
            coll.gameObject.layer = 13;
    }
}
