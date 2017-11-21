using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * MoveTrail.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.11.19
 * @since 17.10.10
 */
public class MoveTrail : MonoBehaviour
{
    /**
     * Speed of the trail.
     *
     * @unityParam
     * @since 17.10.10
     */
    [SerializeField]
    private float Speed = 50f;

    /**
     * Move the trail.
     *
     * @since 17.10.10
     */
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        Destroy(gameObject, 1);
    }

    /**
     * Kill the player if he got hit by the trail.
     *
     * @param collider the object
     * @since 17.10.10
     */
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.CompareTo("Turret") != 0)
        {
            if (collider.tag.CompareTo("Rob") == 0 && collider.name.CompareTo("Rob.B") != 0)
            {
                Restarter.isDead = true;
            }
            Destroy(gameObject);
        }
    }

}
