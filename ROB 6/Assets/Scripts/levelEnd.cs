using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//scene is set by default the programm will load the next scene id \\
//overwise it will load the given scene adress\\

public class levelEnd : MonoBehaviour
{

    private bool is_end = false;
    private float fade_time;

    public float timer = 0.4f;
    public AudioClip sound;
    public int scene = -1;
    public float speed;

    void Update()
    {
        if (is_end)
        {
            //wait until the end of the animation and the sound\\
            timer = timer - Time.deltaTime;
            //when the animation and the sound end load the next level\\
            if (timer <= 0)
            {
                if (scene == -1)
                    SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex + 1);
                else
                    SceneManager.LoadScene(scene);
            }
        }
    }

    IEnumerator change_level()
    {
        fade_time = GameObject.Find("fade").GetComponent<fading>().begin_fade(1);
        AudioSource.PlayClipAtPoint(sound, transform.position);
        yield return new WaitForSeconds(fade_time);
        if (scene == -1)
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex + 1);
        else
            SceneManager.LoadScene(scene);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rob")
        {
            fade_time = GameObject.Find("fade").GetComponent<fading>().begin_fade(1);
            AudioSource.PlayClipAtPoint(sound, transform.position);
            change_level();
            is_end = true;
        }
    }
}