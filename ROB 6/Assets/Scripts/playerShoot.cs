using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {

    private GameObject flip;
    private float cooldown = 0f;

    public GameObject shoot;
    public GameObject spawnpoint;

	// Update is called once per frame
	void Update ()
    {
        cooldown = cooldown - Time.deltaTime;
        if (Input.GetKeyDown("c") && cooldown <= 0)
        {
            Instantiate(shoot, spawnpoint.transform.position, Quaternion.identity);
            cooldown = 0.3f;
        }
    }
}
