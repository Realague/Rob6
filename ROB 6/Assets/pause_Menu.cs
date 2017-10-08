using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause_Menu : MonoBehaviour {

    public GameObject menu;
    private bool active;

    // Use this for initialization
    void Start () {
        menu.SetActive(false);
        active = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && active == false)
        {
            Time.timeScale = 0;
            moveCursor.close = false;
            menu.SetActive(true);
            active = true;
            playerController.stop = true;
        }
       else if (Input.GetKeyDown(KeyCode.Escape) && active == true || moveCursor.close == true)
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            active = false;
            playerController.stop = false;
        }
    }
}
