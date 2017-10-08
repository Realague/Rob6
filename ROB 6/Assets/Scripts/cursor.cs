using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cursor : MonoBehaviour {

    public Camera cam;
    public static Rigidbody2D rb;
    public GameObject spawn;
    public static GameObject current;
    public GameObject[] players;
    private SpriteRenderer[] signals;
    public static SpriteRenderer stock;
    private float timer;
    private float speed = 2f;
    private float alpha = 1;
    private bool positive = false;
    public static GameObject[] allPlayers;

    /* 
    ** ceci est la variable qui stock tout les inventaires de nos rob 
    ** chaque case du dictionnaire contient une liste de gamobject qui est 
    ** l'inventaire individuel des rob, les clé du dictionnaire sont les
    ** nom des rob 
    ** 
    ** @author              Rémi Wickuler
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */

    public static Dictionary<string, List<GameObject>> inventory = null;

    /*
    ** met le cursuer en invisible, initialise le rob du debut, 
    ** désactive le logo "no signal" et permet d'igniorer les colision entre rob
    ** et initialisation de l'inventaire
    **
    ** @author              Rémi Wickuler
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */

    void Start() {
        if (SceneManager.GetActiveScene().buildIndex >= gameControl.level)
        {
            gameControl.level = SceneManager.GetActiveScene().buildIndex;
            gameControl.control.save();
        }
        allPlayers = players;
        inventory = new Dictionary<string, List<GameObject>>();
        Cursor.visible = false;
        current = spawn;
        if (current.transform.name == "Rob.I" || current.transform.name == "Rob.B")
                    playerController.anim = current.GetComponent<Animator>();
        foreach (GameObject player1 in players)
        {
            List<GameObject> scrap = null;
            inventory.Add(player1.name, scrap);
            signals = player1.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sprite in signals)
                if (sprite.tag == "signal")
                    sprite.enabled = false;
            foreach (GameObject player2 in players)
            {
               Physics2D.IgnoreCollision(player1.GetComponent<Collider2D>(), player2.GetComponent<Collider2D>(), true);
            }
        }
	}
	
    /*
    ** gere le changement de personnage en prenant en charge les problemes de layers 
    ** et en mettant une limite de distance
    **
    ** @author              Rémi Wickuler
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */

	void Update () {
        int layer;
        float closer = 100;
        GameObject coll = null;

        if (Input.GetKeyDown(KeyCode.LeftShift) && playerController.stop == false)
        {
            foreach (GameObject player in players)
            {
                if (closer > Vector3.Distance(current.transform.position, player.transform.position) && player.name != current.name && 
                    (playerController.fly == null || (playerController.fly != null && playerController.fly.name != player.name)))
                {
                    closer = Vector3.Distance(current.transform.position, player.transform.position);
                    coll = player;
                }
            }
            if (closer <= 18f && coll != null)
            {
                if (stock != null)
                    stock.enabled = false;
                layer = current.GetComponent<SpriteRenderer>().sortingOrder;
                current.GetComponent<SpriteRenderer>().sortingOrder = coll.GetComponent<SpriteRenderer>().sortingOrder;
                coll.GetComponent<SpriteRenderer>().sortingOrder = layer;
                current.GetComponent<playerController>().enabled = false;
                if (current.transform.name == "Rob.I" || current.transform.name == "Rob.B")
                    playerController.anim.SetBool("run", false);
                current = coll.gameObject;
                current.GetComponent<playerController>().enabled = true;
                if (current.transform.name == "Rob.I" || current.transform.name == "Rob.B")
                    playerController.anim = current.GetComponent<Animator>();
            }
            else
            {
                signals = current.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer sprite in signals)
                    if (sprite.tag == "signal")
                    {
                        timer = Time.time + speed;
                        stock = sprite;
                        stock.enabled = true;
                    }
            }
        }
        flash();
    }

    /*
    ** fait clignoter le sprite no sgnial
    **
    ** @author              Rémi Wickuler
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */

    void flash()
    {
        if (timer > Time.time)
        { 
            stock.color = new Color(1, 1, 1, alpha);
            if (alpha <= 0)
                positive = true;
            else if (alpha >= 1)
                positive = false;
            if (positive == false)
                alpha -= 0.1f;
            else
                alpha += 0.1f;
        }
        else if (stock != null)
        {
            stock.color = new Color(1, 1, 1, 1);
            stock.enabled = false;
        }
    }

}
