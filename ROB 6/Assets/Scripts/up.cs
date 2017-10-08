using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour {

    private bool go = false;
    private float timer;
    public bool auto;
    private float speed = 0.001f;

	// Use this for initialization
	void Start () {
        timer = Time.time + speed;
	}
	
	// Update is called once per frame
	void Update () {
        if (auto == true)
            go = true;
       if (go == true && timer <= Time.time && (transform.position.y < 0f || auto == false))
        {
            transform.Translate(new Vector3(0, 0.1f));
            timer = Time.time + speed;
        }
		
	}

    void OnCollisionStay2D(Collision2D coll)
    {
        if (Input.GetKey("e"))
        {
            go = true;
            timer = Time.time + speed;
        }
    }
}
