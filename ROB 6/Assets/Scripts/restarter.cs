using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restarter : MonoBehaviour {

    private float timer = 0.5f;
    private bool death = false;
    Animator anim;

    public AudioClip sound;

    private void Start()
    {
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        //catch the if player press r\\
        if ((Input.GetKeyDown(KeyCode.R) || playerController.death == true) && !death)
        {
            GameObject.Find("fade").GetComponent<fading>().begin_fade(1);
            death = true;
            playerController.death = false;
            //maybe play an audio when he restart\\
        }
        //wait the end of the sound and animation to reset the lvl\\
        if (death)
        {
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                playerController.facingRight = true;
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
                //anim.SetBool("death", false);
            }
        }
    }

    /*IEnumerator dead()
    {
        Debug.Log("ps");
        float fade_time = 7;
        //fade_time = GameObject.Find("fade").GetComponent<fading>().begin_fade(1);
        AudioSource.PlayClipAtPoint(sound, transform.position);
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        yield return new WaitForSeconds(fade_time);
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        //play the sound and the animation of death\\
        if (other.tag == "Death" && !death)
        {
            GameObject.Find("fade").GetComponent<fading>().begin_fade(1);
            AudioSource.PlayClipAtPoint(sound, transform.position);
        //Debug.Log("plt");
            //dead();
            //anim.SetBool("death", true);
            death = true;
        }
    }
}
