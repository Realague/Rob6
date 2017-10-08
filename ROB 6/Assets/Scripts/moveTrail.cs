using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTrail : MonoBehaviour {

    public float Speed = 50f;
    public GameObject turret;

    /*
    ** dépalce le tire
    **
    ** @author              Rémi Wickuler
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        Destroy(gameObject, 1);
    }

    /*
    ** gere la mort du player
    **
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
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
