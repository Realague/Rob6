using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * CameraChange.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.11
 * @since 17.10.05
 */
public class cameraChange : MonoBehaviour {

   /**
    * Timer until camera move.
    *
    * @unityParam
    * @since 17.10.10
    */
   float timer;

   /**
    * Speed of the trail.
    *
    * @unityParam
    * @since 17.10.10
    */
   float speed = 0.3f;

   /**
    * Path to reach the targeted rob.
    *
    * @since 17.10.10
    */
   private Vector3 offset;

   /**
    * Camera to move.
    *
    * @since 17.10.10
    */
   private Camera cam;

   /**
    * GameObject.
    *
    * @unityParam
    * @since 17.10.10
    */
   public GameObject current;

   /**
    * TrailRenderer.
    *
    * @since 17.10.10
    */
   private TrailRenderer trail;

    /**
     * Initialize the trail and the camera.
     *
     * @since 17.10.05
     */
    void Start()
    {
        trail = GetComponentInChildren<TrailRenderer>();
        trail.enabled = false;
        current = cursor.current;
        offset = transform.position - cursor.current.transform.position;
        cam = GetComponent<Camera>();
    }

    /**
     * Zoom in and zoom out of the camera with tab.
     *
     * @since 17.10.05
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

    /**
     * Small movement of the camera with the left control key.
     *
     * @since 17.10.05
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

   /**
    * Manage the camera movement.
    *
    * @since 17.10.05
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
