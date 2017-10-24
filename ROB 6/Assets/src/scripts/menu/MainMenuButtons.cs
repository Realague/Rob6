using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public AudioClip button_sound;

    private float wait = -1f;
    private bool is_pressed = false;
    private int action = 0;

	// Update is called once per frame
	public void Update ()
    {
        if (is_pressed)
        {
            //wait = wait - Time.deltaTime;
            //wait ther end of the sound played\\
            //if (wait <= 0)
            //{
                //when the sound is end do the action link to the button pressed\\
                switch (action)
                {
                    case 1:
                        SceneManager.LoadScene(3);
                        break;
                    case 2:
                        Application.Quit();
                        break;
                    case 3:
                        SceneManager.LoadScene("Control");
                        break;
                    case 4:
                        SceneManager.LoadScene("NewMenu");
                        break;
                }
            //}
        }
        if (wait <= 0)
            is_pressed = false;
    }

    public void StartGame ()
    {
        pressed();
        action = 1;
    }

    public void ExitGame ()
    {
        pressed();
        action = 2;
    }

    public void OpenOption()
    {
        pressed();
        action = 3;
    }

    public void OpenMenu()
    {
        pressed();
        action = 4;
    }

    //play the sound and init var for the update function
    void pressed()
    {
        AudioSource.PlayClipAtPoint(button_sound, transform.position);
        is_pressed = true;
        wait = 1.5f;
    }
}
