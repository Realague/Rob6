using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * DestroyTrail.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.09
 * @since 17.10.05
 */
public class DestroyTrail : MonoBehaviour{

    /**
     * Delete the trail when he it something.
     *
     * @param collider object.
     * @since 17.10.05
     */
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "trail(Clone)")
        {
            Destroy(collider.gameObject);
        }
    }
}
