using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : MonoBehaviour {

    public float maxSpeed = 5f;
    public float accelerationTime = 1f;
    public float rotateDegreesPerSec = 180f;
    public float trackSegLength = .15f;
    public int trackSegCount = 100;
    public Transform[] wheels;
    public ParticleSystem Utaaparticle;
    public Material trailMaterial;

    public AudioClip[] sounds;
    AudioSource audioSource;


    // public bool carStopped=false;

    public GameObject Trail;

    Rigidbody m_RigidBody;


    [SerializeField]
    private Transform m_VelDir;
    
    float m_AppliedSpeed = 0;
    private List<WheelTrack> m_WheelTracks;
    private Vector3 m_LastPos;


    // turn over
    public bool leftt = false;
    public bool rightt = false;

    int larry,laurent;
    
    [SerializeField]
    int HoldTimeLeft=0;
    
    [SerializeField]
    int HoldTimeRight=0;

    
    void Start()
    {
        
        Utaaparticle.Pause();


        // audioSource = GetComponent<AudioSource>();
        
        m_RigidBody = GetComponent<Rigidbody>();

        m_VelDir = new GameObject().transform;
        m_VelDir.parent = transform;
        m_VelDir.localPosition = Vector3.zero;
        m_VelDir.localEulerAngles = Vector3.zero;
        m_LastPos = transform.position;

        m_WheelTracks = new List<WheelTrack>();
        for (int i = 0; i < wheels.Length; i++)
        {
            WheelTrack wheel = new WheelTrack();
            wheel.Init(wheels[i], trailMaterial, trackSegCount);

            m_WheelTracks.Add(wheel);
        }
    }





    void Update()
    {


// __ PLAYING __ //
        if(GameManager.Instance.IsPlay())
        {



        #region Baaduu; 

        // before
        // if (touchAxis.GetAxis("Horizontal") != 0)
        if (laurent != 0 && larry != 0)
        {
            Utaaparticle.Play();
            //Utaaparticle.loop = true;
        }
        else
        {
            Utaaparticle.Pause();
        }
        #endregion

        
        
        if(Input.GetKey("a") || leftt)
        {
            larry = -1; laurent = 1;

            wheels[0].transform.localEulerAngles = new Vector3(0, 30, 0);
            wheels[1].transform.localEulerAngles = new Vector3(0, 30, 0);
            
            HoldTimeRight=0;
            
            if(HoldTimeLeft <= 20)
            {
                HoldTimeLeft ++;
                
                wheels[0].transform.localEulerAngles = new Vector3(0, -30, 0);
                wheels[1].transform.localEulerAngles = new Vector3(0, -30, 0);
            }

        } else

        if(Input.GetKey("d") || rightt)
        {
            larry = 1;  laurent = -1;
            {
                wheels[0].transform.localEulerAngles = new Vector3(0, -30, 0);
                wheels[1].transform.localEulerAngles = new Vector3(0, -30, 0);
            }
        
            HoldTimeLeft=0;

            if(HoldTimeRight <= 20)
            {
                HoldTimeRight ++;

                wheels[0].transform.localEulerAngles = new Vector3(0, 30, 0);
                wheels[1].transform.localEulerAngles = new Vector3(0, 30, 0);
            }
            
        }else{
            larry = 0;   laurent = 0;

            HoldTimeLeft = 0;
            HoldTimeRight = 0;

            wheels[0].transform.localEulerAngles = new Vector3(0, 0, 0);
            wheels[1].transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        



        // __ Dead zone __ //
        Vector3 offset = transform.position - new Vector3(0,0,0);

        Vector3 limt = new Vector3(0,0,0) + Vector3.ClampMagnitude(offset, 7.5f);

        if(transform.position.magnitude > limt.magnitude)
        {
            // Debug.Log("You lost!");
            m_RigidBody.velocity = Vector3.zero;
            GameManager.Instance.GameOver();
        }
        



        
            // __ GROWING __//
            if(!GrowManager.Instance.touchedGrow)
            {


                
                
                m_AppliedSpeed = m_RigidBody.velocity.magnitude; 


                // Herev Odoogoor bid hamgiin hurdnaaraa ywj chadahgui bol ...
                if (m_AppliedSpeed < maxSpeed)
                {
                    if (m_AppliedSpeed < 0.5f)
                        m_VelDir.localEulerAngles = Vector3.zero;
                        // print("m_VelDir.localEulerAngles" + m_VelDir.localEulerAngles);

                    // Aajmaar hurdlah  
                    m_AppliedSpeed += maxSpeed * Time.deltaTime * accelerationTime;

                        // print("m_AppliedSpeed" + m_AppliedSpeed);
                }

                float zVal;


                // Represent the difference between the car's pointing direction and travel direction as a float ranging -1 to 1. 


                float angleOffset = Remap((Mathf.DeltaAngle(transform.eulerAngles.y, m_VelDir.transform.eulerAngles.y)), -90, 90, -1, 1);
                
            
                if (larry == 0 && laurent == 0)
                {
                    // If not actively turning, straighten out gradually.
                    zVal = transform.eulerAngles.y + m_AppliedSpeed * angleOffset / 3 * 4;
                    // print("zVal" + zVal);
                }   
                else
                {
                    // Turn over n degrees per second, scaled by joystick input value.
                    zVal = transform.eulerAngles.y + rotateDegreesPerSec * Time.deltaTime * larry;
                    // print("zVal" + zVal);
                }


                // Apply new rotation 
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, zVal, transform.eulerAngles.z);
                
                
                // Determine travel velocity. The car may be moving perfectly "sideways," traveling 90 deg from car's forward.
                m_VelDir.localEulerAngles = new Vector3(
                            0,
                            Mathf.LerpAngle(m_VelDir.localEulerAngles.y,  laurent * 90f,  Time.deltaTime),
                            0);


                if (Vector3.Distance(transform.position, m_LastPos) > trackSegLength)
                {
                    m_LastPos = transform.position;

                    Color newAlpha = Color.black;
                        newAlpha.a = Mathf.Min(Mathf.Abs(angleOffset), .5f);
                    foreach (WheelTrack wheel in m_WheelTracks)
                    {
                        wheel.AddSegment(newAlpha);
                    }
                }
            }
        }
    }


    // Linear remap
    float Remap(float m_deltaAngle, float srcMin, float srcMax, float destMin, float destMax)
    {
                          // -1       1                            -90      90     DeltaAngle  
        return Mathf.Lerp(destMin, destMax,     Mathf.InverseLerp(srcMin, srcMax, m_deltaAngle));
    }


    void LateUpdate()
    {
        if(GameManager.Instance.IsPlay())
        {
            if(!GrowManager.Instance.touchedGrow)
            {
                // Move the car
                m_RigidBody.velocity = m_VelDir.forward * m_AppliedSpeed;
            }
        }

        if(GameManager.Instance.isSuccess())
        {
            m_RigidBody.velocity = Vector3.zero;
        }

        if(GrowManager.Instance.touchedGrow)
        {
            m_RigidBody.velocity = Vector3.zero;
        }
    }

    void EilerWheel(int DegA, int DegB)
    {
        wheels[0].transform.localEulerAngles = new Vector3(0, DegA, 0);
        wheels[1].transform.localEulerAngles = new Vector3(0, DegB, 0);
    }


    private class WheelTrack
    {
        private List<Transform> lines;
        private Vector3 lastPos;
        private Transform transform;
        private Transform lineHolder;
        private int lineIndex = 0;
        private Material mat;
        private int segmentCount;
        
        public void Init(Transform tf, Material material, int segCount)
        {
            lines = new List<Transform>();
            transform = tf;
            mat = material;
            segmentCount = segCount;
            lineHolder = new GameObject(transform.name + "Tracks").transform;
        }
        public void AddSegment(Color color)
        { 
            if (lines.Count < segmentCount)
            {
                GameObject go = new GameObject();
                go.transform.parent = lineHolder;

                LineRenderer newLine = go.AddComponent<LineRenderer>();
                newLine.material = mat;
                newLine.startWidth = newLine.endWidth = .05f;
                newLine.positionCount = 2;

                lines.Add(go.transform);
            }

            LineRenderer line = lines[lineIndex].GetComponent<LineRenderer>();
            line.SetPosition(0, transform.position);
            line.SetPosition(1, lastPos);
            line.startColor = line.endColor = color;

            lastPos = transform.position;
            lineIndex = (lineIndex + 1) % segmentCount;
        }
    }

    // Sound
    // public void PlaySound(int id)
	// {
	// 	audioSource.Stop();
	// 	audioSource.clip = sounds[id];
	// 	audioSource.Play();
	// }


}
