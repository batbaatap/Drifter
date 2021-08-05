using System.Collections;
using System.Collections.Generic;
// using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class lineGenerator : MonoBehaviour {

	public static lineGenerator Instance { get; private set; }

	// grow 
    // public bool isGrowing=false;
    public int GrowLiveTime=0;
    public bool StartLiveGrowTime=false;
    public bool unscale=false;

    public int growlength;

	public Transform pointA, pointB;
	
	LineRenderer line;

	CapsuleCollider capsule;

	public float ColliderWidth;

	private float AnhniZai;

	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer>();
		capsule = gameObject.AddComponent<CapsuleCollider>();
		capsule.radius = ColliderWidth / 2;
		capsule.center = Vector3.zero;
		capsule.direction = 2;

		pointA = GameObject.Find("linePoint").transform;
		pointB = GameObject.Find("Trail").transform;
		
		AnhniZai = Vector3.Distance(pointA.transform.position, pointB.transform.position);
		print(AnhniZai);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// if(isGrowing == true)
        // {
        //     Grow();
        // }

		line.SetPosition(0, pointA.position);
		line.SetPosition(1, pointB.position);

		// if(GameManager.Instance.IsPlay())
		// {

		capsule.transform.position = pointA.position+(pointB.position - pointA.position) / 2;
		 
		// }
		// print(capsule.transform.position);

		capsule.transform.LookAt(pointA.position);
		capsule.height = (pointB.position - pointA.position).magnitude;

		
		var YnzZai = Vector3.Distance(pointA.transform.position, pointB.transform.position);


		if(GrowManager.Instance.touchedGrow)
		{	

			StartLiveGrowTime=true;

			pointB.transform.Translate(-Vector3.forward * Time.deltaTime);
				ColorChanger(Color.red);
	
			if(YnzZai >= 2f)
			{
				ColorChanger(Color.white);
				GrowManager.Instance.touchedGrow = false;
			}
		}


		if(StartLiveGrowTime)
		{
			GrowLiveTime++;

			if(GrowLiveTime >= 500)
			{
				StartLiveGrowTime=false;
				unscale = true;
			}
		}

		if(unscale==true)
		{
			pointB.transform.Translate(Vector3.forward * Time.deltaTime);
			ColorChanger(Color.red);
			if(YnzZai <= AnhniZai)
			{
				ColorChanger(Color.white);

				unscale=false;
				GrowLiveTime=0;
			}
		}

	}

	void ColorChanger(Color ungu)
	{
		Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(ungu, 0.0f), new GradientColorKey(ungu, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1f, 0.0f), new GradientAlphaKey(1f, 1.0f) }
        );

        line.colorGradient = gradient;
	}
}
