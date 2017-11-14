using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour {

	private PointEffector2D mag;
	private char charge;

	// Use this for initialization
	void Start () {
		mag = GetComponentInChildren<PointEffector2D>();
		mag.forceMagnitude = 0;
		charge = '0';
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.name == PlayerManager.current.name && Input.GetKeyDown("e") && charge != '+')
			charge = '+';
		else if (transform.name == PlayerManager.current.name && Input.GetKeyDown("e") && charge == '+')
			charge = '0';
		if (transform.name == PlayerManager.current.name && Input.GetKeyDown("f") && charge != '-')
			charge = '-';
		else if (transform.name == PlayerManager.current.name && Input.GetKeyDown("f") && charge == '-')
			charge = '0';
		switch(charge)
		{
			case '-':
				mag.forceMagnitude = 200;
				GetComponentInChildren<Light>().enabled = true;
				GetComponentInChildren<Light>().color = Color.blue;
				break;
			case '+':
				mag.forceMagnitude = -200;
				GetComponentInChildren<Light>().enabled = true;
				GetComponentInChildren<Light>().color = Color.red;
				break;
			case '0':
				mag.forceMagnitude = 0;
				GetComponentInChildren<Light>().enabled = false;
				break;
		}
	}
}
