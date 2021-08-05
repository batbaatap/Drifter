using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapGenerator : MonoBehaviour {
    public static MapGenerator instance {get;  private set;}
    public List<GameObject> AllGrass = new List<GameObject>();
    public float grassPoint;                          //number of points on radius to place prefabs

    public Vector3 centerPos = new Vector3(0,0,0);    //center of circle/elipsoid
 
    public GameObject[] pointPrefab;                    //generic prefab to place on each point
    public float radiusX, radiusZ;                  //radii for each x,y axes, respectively
    public bool isCircular = false;                 //is the drawn shape a complete circle?

    public bool vertical = true;                 //is the drawb shape on the xy-plane?
    
    public int stack;
    public int minusGrass;
    public int leftMinusGrass;


    public float minusRadiusX;
    public float minusRadiusZ;


    // public GameObject holder;


    // public int distanceGrass=2;
    private Vector3 pointPos;                                //position to place each prefab along the given circle/eliptoid


    // Use this for initialization
    void Start () {
       SpawnGrass();
    }

    void Update()
    {
        for(var i = 0; i < AllGrass.Count; i++) 
        {
            if(AllGrass[i] == null)
            {
                AllGrass.RemoveAt(i);
            }
        }

        if(AllGrass.Count == 0)
        {
            // SpawnGrass(2, 2);
            GameManager.Instance.Success();
            // GameManager.Instance.gameState = GameManager.States.Success;
            // UnityEngine.SceneManagement.SceneManager.LoadScene(0);

            // Debug.Log("You won!");
        }
    }

    public void SpawnGrass()
    {
        // float perimeter = Mathf.PI;
        // Debug.Log("The perimeter of the circle is: " + perimeter);
        // for(int k = 0; k < 40; k++)
        // {
        // float rNumX = Random.Range(0.6f, 1);
        // float rNumY = Random.Range(0.3f, 1);

        // radiusX -= minusRadiusX;
        // radiusZ -= minusRadiusZ;

        // if(1 < grassPoint)
        // {
        //     grassPoint -= minusGrass;
        // }

        // if(15 > grassPoint)
        // {
        //     grassPoint = leftMinusGrass;
        // }

        // for(int i = 0; i < grassPoint; i++){
        //     // multiply 'i' by '1.0f' to ensure the result is a fraction
        //     float pointNum = (i*1.0f)/grassPoint;

        //     // print((i*1.0f)/grassPoint);

        //     // angle along the unit circle for placing points
        //     float angle = pointNum*Mathf.PI*2;

        //     float x = Mathf.Sin (angle) * radiusX;
        //     float z = Mathf.Cos (angle) * radiusZ;

        //     //position for the point prefab
        //     if(vertical)
        //         pointPos = new Vector3(x, z)+centerPos;
        //     else if (!vertical){
        //         pointPos = new Vector3(x, 0, z)+centerPos;
        //     }

        //     //place the prefab at given position
        //     var prefabGrass = Instantiate (pointPrefab, pointPos, Quaternion.identity);

        //         AllGrass.Add(prefabGrass);
        //         prefabGrass.transform.parent = transform;

        // }


        //keeps radius on both axes the same if circular
        // if(isCircular){
        //     radiusZ = radiusX;
        // }
        int Rid = Random.Range(0, pointPrefab.Length); //random grass type

            float posx = 0, posz = 0;

            for(int i=0; i<20; i++){

                for(int j=0; j<20; j++){
                    Vector3 position = new Vector3(posx, 0, posz);
                    
                    GameObject gg = Instantiate(pointPrefab[Rid], position, Quaternion.identity) as GameObject;
                    gg.transform.SetParent(gameObject.transform, false);
                   

                    AllGrass.Add(gg);

				    // gg.transform.parent = gameObject.transform;

                    posz = posz + 0.22f;
                }

                posz = 0;
                posx = posx + 0.22f;

            }

            


            
            
        // }
    }

    
    
}



