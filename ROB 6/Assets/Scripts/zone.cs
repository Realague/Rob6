using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Zone.
 * Script use for the turret
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.11
 * @since 17.10.11
 */
public class zone : MonoBehaviour {

    /**
     * Where ray will pawn.
     *
     * @since 17.10.11
     */
    private Transform fire_point;

    /**
     * Cooldown of the turret.
     *
     * @since 17.10.11
     */
    private float cooldown = 0.05f;

    /**
     * List of sound.
     *
     * @since 17.10.11
     */
    private AudioSource[] lol;

    /**
     * List containing the distance between the turret and all the rob.
     *
     * @unityParam
     * @since 17.10.11
     */
    public GameObject[] dist;

    /**
     * The ray.
     *
     * @unityParam
     * @since 17.10.11
     */
    public GameObject line_shot;

    /**
     * Distance with the shortest rob.
     *
     * @since 17.10.11
     */
    private float shortest;

    /**
     * Temp var to find the shortest rob.
     *
     * @since 17.10.11
     */
    private float tmp;

    /**
     * Raycast to the target.
     *
     * @unityParam
     * @since 17.10.11
     */
    public static RaycastHit2D hit;

    /**
     * Init the sound and the spawn point of ray.
     *
     * @since 17.10.11
     */
    void Awake()
    {
        lol = GetComponents<AudioSource>();
        fire_point = transform.Find("firePoint");
    }

    /**
     * Manage the cooldown of the turret.
     *
     * @since 17.10.11
     */
	void Update ()
    {
        cooldown -= Time.deltaTime;
    }

    /**
     * Manage who enter in the area, shoot in his direction and work if there are several player in the area.
     *
     * @param collider game object hit
     * @since 17.10.11
     */
    void OnTriggerStay2D(Collider2D Target)
    {
        if (Target.tag == "Rob")
        {
            shortest = Vector2.Distance(this.transform.position, dist[0].transform.position);
            foreach (GameObject rob in dist)
            {
                tmp = Vector2.Distance(this.transform.position, rob.transform.position);
                if (tmp < shortest)
                    shortest = tmp;
            }
            if (shortest == Vector2.Distance(this.transform.position, Target.transform.position))
            {
                Quaternion rotation = Quaternion.LookRotation(Target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
                transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
                if (cooldown <= 0)
                {
                    shoot(Target);
                    cooldown = 0.1f;
                }
            }
        }
    }

    /**
     * Play a sound and create a ray cast.
     *
     * @param target of the ray
     * @since 17.10.11
     */
    void shoot (Collider2D Target)
    {
        if (!lol[0].isPlaying)
            lol[0].Play();
        hit = Physics2D.Raycast(fire_point.position, fire_point.forward);
        effect();
    }

    /**
     * If the player exit the area stop the sound and play another.
     *
     * @param collider the game object hit
     * @since 17.10.11
     */
    void OnTriggerExit2D(Collider2D Target)
    {
        if (Target.tag == "Rob")
        {
            lol[0].Stop();
            lol[1].Play();
        }
    }

    /**
     * If a player enter in the area play a sound.
     *
     * @param collider the game object hit
     * @since 17.10.11
     */
    void OnTriggerEnter2D(Collider2D Target)
    {
        if (Target.tag == "Rob")
        {
            lol[0].Play();
        }
    }

    /**
     * Create ray.
     *
     * @since 17.10.11
     */
    void effect()
    {
        Instantiate(line_shot, fire_point.position, fire_point.rotation);
    }
}
