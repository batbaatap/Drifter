using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsController : MonoBehaviour {

	public GameObject Gem;
	int amountOfObjectCreated;


	// Use this for initialization
	void Start () {
		// transform.position = Random.insideUnitCircle * 5;
		InstantiateRandom();
	}

	void InstantiateRandom()
    {
        // Vector3 sphericalPosition = Random.insideUnitSphere * 10;
     
        // Constrain position
        // sphericalPosition.y = Mathf.Abs(sphericalPosition.y);
        // Vector3 objectPos = sphericalPosition;
		for (int i = 0; i < 5; i++)
		{
			Gem = Instantiate(Gem) as GameObject;
		}
 
        // GameObject temp = Instantiate(Gem, objectPos, Quaternion.identity) as GameObject;
		
		Gem.transform.position =  new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z) * 6;

    }

	
	// Update is called once per frame
	// void Update ()
	// {
	// 	if(GameManager.Instance.IsStart())
	// 	{
    //     	amountOfObjectCreated++;
			
    //     	// playerPosition = GameObject.Find("Head").transform.position;
	// 		if (amountOfObjectCreated < 20)
	// 		{

	// 			var v = OnUnitSphere() * 5f;
				
	// 			Instantiate(Gem, v, Quaternion.identity);
		
	// 		}
	// 	}
    // }

	// public static UnityEngine.Vector3 OnUnitSphere()
	// {
	// 	//uniform, using angles
	// 	var a = Random.value * Mathf.PI * 2f;
	// 	var b = Random.value * Mathf.PI * 2f;
	// 	var sa = Mathf.Sin(a);
	// 	// return new Vector3(sa * Mathf.Cos(b), sa * Mathf.Sin(b), Mathf.Cos(a));
	// 	return new Vector3(sa * Mathf.Cos(b), 0, Mathf.Cos(a));
	// }


	//toirgoor dotor instantiate hiih

	// void InstantiateCircle () 
	// {
	// 	float angle = 360f / (float)pieceCount;
	// 	for (int i = 0; i < pieceCount; i++)
	// 	{
	// 		Quaternion rotation = Quaternion.AngleAxis(i * angle, Vector3.up);
	// 		Vector3 direction = rotation * Vector3.forward;
	
	// 		Vector3 position = centerPos + (direction * radius);
	// 		Instantiate(prefab, position, rotation);
	// 	}
	// }

}
