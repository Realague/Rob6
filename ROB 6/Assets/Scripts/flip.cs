using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    private BoxCollider2D[] colliders;

    public GameObject spawnPlat;

    // Use this for initialization
    void Start()
    {
        if (cursor.current.transform.localScale.x < 0)
            spawnPlat.transform.localScale = new Vector2(spawnPlat.transform.localScale.x * -1, spawnPlat.transform.localScale.y);
        colliders = GetComponents<BoxCollider2D>();
        foreach (GameObject player in cursor.allPlayers)
        {
            Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), colliders[0], true);
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "Rob")
        {
            Physics2D.IgnoreCollision(coll, colliders[0], false);
            if (Input.GetKey("s") && coll.name == cursor.current.name)
                Physics2D.IgnoreCollision(coll, colliders[0], true);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Rob")
        Physics2D.IgnoreCollision(coll, colliders[0], true);
    }
}
