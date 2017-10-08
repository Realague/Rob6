using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    private int i = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("s"))
            i++;
        else if (Input.GetKeyDown("z"))
            i--;
        if (i < 0)
            i = 2;
        else if (i > 2)
            i = 0;
        cursorPosition();
        select();
    }


    void cursorPosition()
    {
        if (i == 0)
            transform.position = new Vector2(4, 0);
        else if (i == 1)
            transform.position = new Vector2(4, -1.75f);
        else if (i == 2)
            transform.position = new Vector2(4, -3.5f);
    }

    void select()
    {
        if (Input.GetKeyDown("space"))
            switch (i)
            {
                case 0:
                    gameControl.control.load();
                    SceneManager.LoadScene(gameControl.level);
                    break;
                case 1:
                    SceneManager.LoadScene(1);
                    break;
                case 2:
                    Application.Quit();
                    break;

            }
    }
}
