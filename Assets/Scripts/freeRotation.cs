using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeRotation : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// transform.RotateAround(Vector3.up, speed * Time.deltaTime);
		// if(!GrowManager.Instance.touchedGrow)
			transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
	}

}
