using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableCollider : MonoBehaviour {

    private EdgeCollider2D colli;
    
    /*
    ** supprimer ou active les collider en fonction des entrée et sortir d'un deuxieme collider mis en trigger
    ** 
    ** @author              Rémi Wickuler
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */

    void Start()
    {
         colli = GetComponentInParent<EdgeCollider2D>();
         colli.enabled = false;
    }

	void OnTriggerEnter2D(Collider2D coll)
    {
       if (coll.tag == "Rob")
        {
            colli.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Rob")
        {
            colli.enabled = false;
        }
    }
}
