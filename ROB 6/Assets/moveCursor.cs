using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveCursor : MonoBehaviour {

    private int i = 0;
    public static bool close;

	// Use this for initialization
	void Start () {
        close = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
            i--;
        else if (Input.GetKeyDown(KeyCode.S))
            i++;
        if (i > 1)
            i = 0;
        else if (i < 0)
            i = 1;
        switch (i)
        {
            case 0:
                transform.position = new Vector2(transform.position.x, 750);
                if (Input.GetKeyDown(KeyCode.Space))
                    close = true;
                break;
            case 1:
                transform.position = new Vector2(transform.position.x, 550);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Time.timeScale = 1;
                    playerController.stop = false;
                    SceneManager.LoadScene(0);
                }
                break;
        }
	}
}
