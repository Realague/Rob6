using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 //TODO: Doc
public class FlipCreatedObject : MonoBehaviour
{

    private BoxCollider2D[] colliders;

    public GameObject spawnPlat;

    private void Start()
    {
        if (PlayerManager.current.transform.localScale.x < 0)
        {
            spawnPlat.transform.localScale = new Vector2(spawnPlat.transform.localScale.x * -1, spawnPlat.transform.localScale.y);
        }
        colliders = GetComponents<BoxCollider2D>();
        foreach (GameObject player in PlayerManager.playersList)
        {
            Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), colliders[0], true);
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag.CompareTo("Rob") == 0)
        {
            Physics2D.IgnoreCollision(collider, colliders[0], false);
            if (Input.GetKey("s") && collider.name == PlayerManager.current.name)
            {
                Physics2D.IgnoreCollision(collider, colliders[0], true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag.CompareTo("Rob") == 0)
        {
            Physics2D.IgnoreCollision(collider, colliders[0], true);
        }
    }
}
