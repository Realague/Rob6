using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraChange : MonoBehaviour {

   float timer;
   float speed = 0.3f;
   private Vector3 offset;
   private Camera cam;
   public GameObject current;
   private TrailRenderer trail;   

    /* 
    ** Initialise le trail et la camera
    **
    ** @author              Rémi Wickuler
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */

    void Start()
    {
        trail = GetComponentInChildren<TrailRenderer>();
        trail.enabled = false;
        current = cursor.current;
        offset = transform.position - cursor.current.transform.position;
        cam = GetComponent<Camera>();
    }

    /* 
    ** zomm et dezoom de la camera avec tab
    **  
    ** @author              Rémi Wickuler
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */

    void Update()
    {
        if (playerController.stop == false)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
                cam.orthographicSize = 20;
            else if (Input.GetKeyUp(KeyCode.Tab))
                cam.orthographicSize = 12;
            moveCamera();
        }
    }
    
    /* 
    ** dplacement leger de la camera avec leftControl
    ** 
    ** @author              Rémi Wickuler
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */

    void moveCamera()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetAxis("Mouse X") > 0 && transform.position.x < cursor.current.transform.position.x + 8)
            {
                transform.Translate(new Vector3(0.5f, 0));
            }
            else if (Input.GetAxis("Mouse X") < 0 && transform.position.x > cursor.current.transform.position.x - 8)
            {
                transform.Translate(new Vector3(-0.5f, 0));
            }
            else if (Input.GetAxis("Mouse Y") > 0 && transform.position.y < cursor.current.transform.position.y + 8)
            {
                transform.Translate(new Vector3(0, 0.5f));
            }
            else if (Input.GetAxis("Mouse Y") < 0 && transform.position.y > cursor.current.transform.position.y - 8)
            {
                transform.Translate(new Vector3(0, -0.5f));
            }
        }
    }

    /* 
    ** remise de la camera a sa position initiale
    ** 
    ** @author              Rémi Wickuler
    ** @last update date    05/10/2017
    ** @creation date       05/10/2017
    */

   void LateUpdate()
    {
        if (playerController.stop == false)
        {
            if (current != cursor.current)
            {
                trail.enabled = true;
                if (transform.position.x > cursor.current.transform.position.x + 0.5)
                    transform.Translate(new Vector2(-1f, 0));
                else if (transform.position.x < cursor.current.transform.position.x - 0.5)
                    transform.Translate(new Vector2(1f, 0));
                if (transform.position.y > cursor.current.transform.position.y + 0.5)
                    transform.Translate(new Vector2(0, -1f));
                else if (transform.position.y < cursor.current.transform.position.y - 0.5)
                    transform.Translate(new Vector2(0, 1f));
                if (transform.position.x > cursor.current.transform.position.x - 0.5 && transform.position.x < cursor.current.transform.position.x + 0.5
                    && transform.position.y > cursor.current.transform.position.y - 0.5 && transform.position.y < cursor.current.transform.position.y + 0.5)
                {
                    timer = Time.time + speed;
                    current = cursor.current;
                }
            }
            else if (Input.GetKey(KeyCode.LeftControl) == false)
                transform.position = current.transform.position + offset;
            if (current == cursor.current && trail.enabled == true && timer <= Time.time)
            {
                trail.enabled = false;
            }
        }
    }
}
