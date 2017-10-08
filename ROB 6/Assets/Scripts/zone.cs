using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zone : MonoBehaviour {

    private Transform fire_point;
    private float cooldown = 0.05f;
    private AudioSource[] lol;
    public GameObject[] dist;
    public GameObject line_shot;
    private float shortest;
    private float tmp;
    public static RaycastHit2D hit;

    /*
    ** Initialise le son et la position ou va apparaitre le tire
    **
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */  


    void Awake()
    {
        lol = GetComponents<AudioSource>();
        fire_point = transform.Find("firePoint");
    }

    /*
    ** delai du tire
    **
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */  


	void Update ()
    {
        cooldown -= Time.deltaTime;
    }

    /*
    ** detecte qui rentre dans la zone de tire et tire dans sa direction
    ** marche aussi quand il y a plusiseur player dans la zone de tire 
    ** (tire sur le plus proche)
    **
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */  


    void OnTriggerStay2D(Collider2D Target)
    {
        if (Target.tag == "Rob")
        {
            shortest = Vector2.Distance(this.transform.position, dist[0].transform.position);
            foreach (GameObject rob in dist)
            {
                tmp = Vector2.Distance(this.transform.position, rob.transform.position);
                if (tmp < shortest)
                    shortest = tmp;
            }
            if (shortest == Vector2.Distance(this.transform.position, Target.transform.position))
            {
                Quaternion rotation = Quaternion.LookRotation(Target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
                transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
                if (cooldown <= 0)
                {
                    shoot(Target);
                    cooldown = 0.1f;
                }
            }
        }
    }

    /*
    ** joue un effet sonor et créé un raycast tout en tirant
    **
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */  
  

    void shoot (Collider2D Target)
    {
        if (!lol[0].isPlaying)
            lol[0].Play();
        hit = Physics2D.Raycast(fire_point.position, fire_point.forward);
        effect();
    }

    /*
    ** arrete l'effet sonor et un joue un autre
    **
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */  


    void OnTriggerExit2D(Collider2D Target)
    {
        if (Target.tag == "Rob")
        {
            lol[0].Stop();
            lol[1].Play();
        }
    }

    /*
    ** joue un effet sonor
    **
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */  


    void OnTriggerEnter2D(Collider2D Target)
    {
        if (Target.tag == "Rob")
        {
            lol[0].Play();
        }
    }

    /*
    ** créé le tire
    **
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */  
 

    void effect()
    {
        Instantiate(line_shot, fire_point.position, fire_point.rotation);
    }
}
