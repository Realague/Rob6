using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coll : MonoBehaviour{

    /* 
    ** supprime le tire quand il touche quelque chose 
    ** 
    ** @author              Rémi Wickuler
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "trail(Clone)")
        {
            Destroy(coll.gameObject);
        }
    }
}
