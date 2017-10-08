using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class curentPlayer : MonoBehaviour {

    private Image current;

    /*
    ** recupère une image et l affiche
    **
    ** @author              Rémi Wickuler
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */
	void Start () {
        current = GetComponent<Image>();
	}


    void Update() {
        current.sprite = cursor.current.GetComponent<SpriteRenderer>().sprite;
    }
}
