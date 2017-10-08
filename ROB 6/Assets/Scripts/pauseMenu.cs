using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    private bool show_pause_menu = false;
    private float wait = 1.5f;
    private bool pressed = false;
    private bool is_pressed = false;

    public GameObject canvas;
    public AudioClip sound;

    // Use this for initialization
    void Start ()
    {
        canvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            show_pause_menu = !show_pause_menu;
            wait = -1f;
            pressed = true;
        }

        if (show_pause_menu == true)
        {
            //play the sound and wait the end\\
            //if (wait == 1.5f)
              //  AudioSource.PlayClipAtPoint(sound, transform.position);
            //wait = wait - Time.deltaTime;
            //display the pause menu\\
            //if (wait <= 0)
            //{
                canvas.SetActive(true);
                Time.timeScale = 0;
            //}
        }
        else
        {
            //hide the pause menu, remove the pause and play the sound\\
            canvas.SetActive(false);
            Time.timeScale = 1;
            if (pressed == true)
            {
                AudioSource.PlayClipAtPoint(sound, transform.position);
                pressed = false;
            }
        }
        if (is_pressed)
        {
            wait = wait - Time.deltaTime;
            //wait ther end of the sound played\\
            if (wait <= 0)
            {
                SceneManager.LoadScene(4);
            }
        }
    }

    public void returnToMenu()
    {
        unpaused();
        Pressed();
    }

    public void unpaused()
    {
        show_pause_menu = !show_pause_menu;
    }

    void Pressed()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        is_pressed = true;
        wait = 1.5f;
    }
}
