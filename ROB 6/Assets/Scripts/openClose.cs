using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openClose : MonoBehaviour {

    private bool button = false;
    private bool col = false;
    private float temp_timer;
    private Vector2 pos_door;
    private int nb_open = 2;

    public AudioClip sound;
    //if true can only interact with the button once\\
    public bool open_once = false;
    //distance of the mouvement of the gameobject\\
    //if negativ will close then open the door otherwise it will open then close\\
    public float distance = 1f;
    //define the time to travel of the distance\\
    public float timer = 1.5f;
    public GameObject door;
    //set the protection level\\
    public bool protection;
    public Text Protected;
    private float timer2;
    private float speed = 5f;
    private float test;


    private void Start()
    {
        if (open_once)
            nb_open = 1;
        pos_door.x = door.transform.position.x;
        pos_door.y = door.transform.position.y;
        distance = -distance;
        Protected.enabled = false;
    }

    void Update ()
    {
        //catch if the button e is pressed and then initialise some value\\
        button = Input.GetKeyDown(KeyCode.E);
        if (button && col && temp_timer <= 0 && (nb_open == 2 || nb_open == 1))
        {
            if (protection == true && cursor.current.name != "Rob.H")
            {
                Protected.enabled = true;
                
            }
            else
            {
                distance = -distance;
                temp_timer = timer;
                button = false;
                pos_door.y = door.transform.position.y;
                Protected.enabled = false;
            }
        }
       if (Protected.enabled == true && timer2 <= Time.time)
        {
            Protected.enabled = false;
        }
       else if (timer2 <= Time.time)
            timer2 = Time.time + speed;
        //play the sound\\
        if (temp_timer == timer)
            AudioSource.PlayClipAtPoint(sound, door.transform.position);
        //move the object\\
        if (temp_timer > 0)
            {
                door.transform.position = new Vector2(pos_door.x, pos_door.y - (distance * (temp_timer - timer) / timer));
                //if we need to interact once\\
                if (nb_open == 1)
                    nb_open = 0;
            }
        temp_timer = temp_timer - Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == cursor.current.name)
            col = true;
        else
            col = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == cursor.current.name)
            col = false;
    }
}

