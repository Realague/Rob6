using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class creationMenu : MonoBehaviour {

    private Canvas can;
    public GameObject select;
    public GameObject[] create;
    public int[] price;
    private int index = 0;
    private Image[] images;
    public GameObject spawnPoint;
    
    /*
    ** Initialise la camera et les sprite pour les images
    ** 
	** @author              Rémi Wickuler
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */
	void Start () {
        can = GetComponent<Canvas>();
        can.enabled = false;
        images = GetComponentsInChildren<Image>();
        images[1].sprite = create[0].GetComponentInChildren<SpriteRenderer>().sprite;
        images[2].sprite = create[1].GetComponentInChildren<SpriteRenderer>().sprite;
    }
	
	/*  
    ** gere le menu de création (curseur et sélection de l objet)
    **
    ** @author              Rémi Wickuler
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */
	void Update() { 
         if (can.enabled == true)
        {
            playerController.stop = true;
        }
        else
        {
            playerController.stop = false;
        }
        if (cursor.current.name == "Rob.I" && Input.GetKeyDown("e") && can.enabled == false)
        {
            can.enabled = true;
        }
        else if (cursor.current.name == "Rob.I" && Input.GetKeyDown("e") && can.enabled == true)
        {
            can.enabled = false;
        }
        if (can.enabled == true)
        {
            if (Input.GetKeyDown("d") && index != create.Length - 1)
            {
                select.GetComponent<Image>().transform.Translate(new Vector2(600, 0));
                index++;
            }
            if (Input.GetKeyDown("q") && index != 0)
            {
                select.GetComponent<Image>().transform.Translate(new Vector2(-600, 0));
                index--;
            }
            if (Input.GetKeyDown("f") && cursor.inventory[cursor.current.name] != null && cursor.inventory[cursor.current.name].Count >= price[index])
            {
                Instantiate(create[index], spawnPoint.transform.position, spawnPoint.transform.rotation);
                can.enabled = false;
                cursor.inventory[cursor.current.name].RemoveRange(cursor.inventory[cursor.current.name].Count - price[index], price[index]);
            }
        }
	}
}

