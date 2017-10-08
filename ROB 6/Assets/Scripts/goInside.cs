using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goInside : MonoBehaviour {

    /* 
    ** change de layer pour modifier la lumière en fonction de l'endroit 
    ** où on se trouve
    **
    ** @author              Rémi Wickuler
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer != 12)
            coll.gameObject.layer = 12;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.layer != 12)
            coll.gameObject.layer = 12;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.layer != 13)
            coll.gameObject.layer = 13;
    }
}
