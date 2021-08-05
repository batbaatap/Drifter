using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowManager : MonoBehaviour
{
    public static GrowManager Instance { get; private set; }
    int amountOfObjectCreated;

    public GameObject PrefabGrow;

    public bool touchedGrow=false;

    void Awake()
    {
        Instance=this;
    }

    // Update is called once per frame
    void Update ()
	{
		if(GameManager.Instance.IsPlay())
		{
            amountOfObjectCreated++;
            
            // playerPosition = GameObject.Find("Head").transform.position;
            if (amountOfObjectCreated < 2)
            {
                var v = OnUnitSphere() * 3f;

                Instantiate(PrefabGrow, v, Quaternion.identity);
            }
		}
    }

	public static UnityEngine.Vector3 OnUnitSphere()
	{
		//uniform, using angles
		var a = Random.value * Mathf.PI * 2f;
		var b = Random.value * Mathf.PI * 2f;
		var sa = Mathf.Sin(a);
		// return new Vector3(sa * Mathf.Cos(b), sa * Mathf.Sin(b), Mathf.Cos(a));
		return new Vector3(sa * Mathf.Cos(b), 0, Mathf.Cos(a));
	}
}
