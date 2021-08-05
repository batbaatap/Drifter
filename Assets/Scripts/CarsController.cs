using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsController : MonoBehaviour
{
    public List<GameObject> Cars = new List<GameObject>();
    public int CarId;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject Cap = Instantiate(Cars[PlayerPrefs.GetInt("ChosenCar", 0)]) as GameObject;
        Cap.transform.position = new Vector3(0,0.1f,0);
        Cap.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
