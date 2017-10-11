using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * MoveTrail.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.10
 * @since 17.10.10
 */
public class moveTrail : MonoBehaviour {

    /**
     * Speed of the trail.
     *
     * @unityParam
     * @since 17.10.10
     */
    public float Speed = 50f;

    /**
     * Turret object.
     *
     * @unityParam
     * @since 17.10.10
     */
    public GameObject turret;

    /**
     * Move the trail.
     *
     * @since 17.10.10
     */
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        Destroy(gameObject, 1);
    }

    /**
     * Kill the player if he got hit by the trail.
     *
     * @since 17.10.10
     */
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name != "turret")
        {
            if (coll.tag == "Rob" && coll.name != "Rob.B")
            {
                playerController.death = true;
            }
            Destroy(gameObject);
        }
    }

}
