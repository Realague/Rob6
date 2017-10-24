using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * CameraChange.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.10.15
 * @since 17.10.05
 */
public class CameraChange : MonoBehaviour
{
   /**
    * Timer until camera move.
    *
    * @unityParam
    * @since 17.10.10
    */
    public float timer;

   /**
    * Speed of the trail.
    *
    * @unityParam
    * @since 17.10.10
    */
   public float speed = 0.3f;

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
    * currentPlayer.
    *
    * @unityParam
    * @since 17.10.10
    */
   public GameObject currentPlayer;

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
    private void Start()
    {
        trail = GetComponentInChildren<TrailRenderer>();
        trail.enabled = false;
        currentPlayer = PlayerManager.current;
        offset = transform.position - PlayerManager.current.transform.position;
        cam = GetComponent<Camera>();
    }

    /**
     * Check if a camera action is performed.
     *
     * @since 17.10.05
     */
    private void Update()
    {
        zoom();
        if (PlayerController.stop == false && Input.anyKeyDown)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                moveCamera();
            }
        }
    }

    /**
     * Zoom in and zoom out of the camera with tab.
     *
     * @since 17.10.15
     */
    private void zoom()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cam.orthographicSize = 20;
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            cam.orthographicSize = 12;
        }
    }

    /**
     * Small movement of the camera with the left control key.
     *
     * @since 17.10.05
     */
    private void moveCamera()
    {
        if (Input.GetAxis("Mouse X") > 0 && transform.position.x < PlayerManager.current.transform.position.x + 8)
        {
            transform.Translate(new Vector3(0.5f, 0));
        }
        else if (Input.GetAxis("Mouse X") < 0 && transform.position.x > PlayerManager.current.transform.position.x - 8)
        {
            transform.Translate(new Vector3(-0.5f, 0));
        }
        else if (Input.GetAxis("Mouse Y") > 0 && transform.position.y < PlayerManager.current.transform.position.y + 8)
        {
            transform.Translate(new Vector3(0, 0.5f));
        }
        else if (Input.GetAxis("Mouse Y") < 0 && transform.position.y > PlayerManager.current.transform.position.y - 8)
        {
            transform.Translate(new Vector3(0, -0.5f));
        }
    }

   /**
    * Manage the camera movement.
    *
    * @since 17.10.05
    */
    private void LateUpdate()
    {
        if (PlayerController.stop == false)
        {
            if (currentPlayer != PlayerManager.current)
            {
                trail.enabled = true;
                if (transform.position.x > PlayerManager.current.transform.position.x + 0.5)
                {
                    transform.Translate(new Vector2(-1f, 0));
                }
                else if (transform.position.x < PlayerManager.current.transform.position.x - 0.5)
                {
                    transform.Translate(new Vector2(1f, 0));
                }
                if (transform.position.y > PlayerManager.current.transform.position.y + 0.5)
                {
                    transform.Translate(new Vector2(0, -1f));
                }
                else if (transform.position.y < PlayerManager.current.transform.position.y - 0.5)
                {
                    transform.Translate(new Vector2(0, 1f));
                }
                if (transform.position.x > PlayerManager.current.transform.position.x - 0.5 && transform.position.x < PlayerManager.current.transform.position.x + 0.5
                    && transform.position.y > PlayerManager.current.transform.position.y - 0.5 && transform.position.y < PlayerManager.current.transform.position.y + 0.5)
                {
                    timer = Time.time + speed;
                    currentPlayer = PlayerManager.current;
                }
            }
            else if (Input.GetKey(KeyCode.LeftControl) == false)
            {
                transform.position = currentPlayer.transform.position + offset;
            }
            if (currentPlayer == PlayerManager.current && trail.enabled == true && timer <= Time.time)
            {
                trail.enabled = false;
            }
        }
    }

}
