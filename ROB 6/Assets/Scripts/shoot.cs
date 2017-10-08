using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public float speed = 100.0f;
    public GameObject my_position;

	// Update is called once per frame
	void Update ()
    {
        my_position.transform.Translate(Vector2.left * (Time.deltaTime * speed));
        Destroy(this.gameObject, 3.0f);
    }
}
