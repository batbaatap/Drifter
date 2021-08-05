using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grass : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Trail" || col.gameObject.tag == "Player" ){
			Destroy(this.gameObject);
		}

		// if(col.gameObject.tag == "Car"){
		// 	this.gameObject.SetActive(false);			
		// }
	}

	
	
	void OnCollisionExit(Collision col)
	{
		if(col.gameObject.tag == "Trail" || col.gameObject.tag == "Player" ){
			
			// print("touched trail");
			// print("red");

			Destroy(this.gameObject);
		}
	}

}
