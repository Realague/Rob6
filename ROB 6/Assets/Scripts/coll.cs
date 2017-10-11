using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Coll.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.09
 * @since 17.10.05
 */
public class coll : MonoBehaviour{

    /**
     * Delete the trail when he it something.
     *
     * @since 17.10.05
     */
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "trail(Clone)")
        {
            Destroy(coll.gameObject);
        }
    }
}
