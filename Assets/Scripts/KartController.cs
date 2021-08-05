using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.Rendering.PostProcessing;
using Cinemachine;

public class KartController : MonoBehaviour
{
    private PostProcessVolume postVolume;
    private PostProcessProfile postProfile;

    public Transform kartModel;
    public Transform kartNormal;
    public Rigidbody sphere;

    // public List<ParticleSystem> primaryParticles = new List<ParticleSystem>();
    // public List<ParticleSystem> secondaryParticles = new List<ParticleSystem>();

    float speed, currentSpeed;
    float rotate, currentRotate;
    int driftDirection;
    float driftPower;
    int driftMode = 0;
    bool first, second, third;
    Color c;

    [Header("Bools")]
    public bool drifting;

    [Header("Parameters")]

    public float acceleration = 30f;
    public float steering = 80f;
    public float gravity = 10f;
    public LayerMask layerMask;

    [Header("Model Parts")]

    public Transform frontWheels;
    public Transform backWheels;
    public Transform steeringWheel;

    [Header("Particles")]
    public Transform wheelParticles;
    public Transform flashParticles;
    public Color[] turboColors;

    int dir;
    public Button lb; float vi;

    public float a;
    public float d;

    public bool left = false;
    public bool right = false;

    void Start()
    {
        // postVolume = Camera.main.GetComponent<PostProcessVolume>();
        // postProfile = postVolume.profile;

        // for (int i = 0; i < wheelParticles.GetChild(0).childCount; i++)
        // {
        //     primaryParticles.Add(wheelParticles.GetChild(0).GetChild(i).GetComponent<ParticleSystem>());
        // }

        // for (int i = 0; i < wheelParticles.GetChild(1).childCount; i++)
        // {
        //     primaryParticles.Add(wheelParticles.GetChild(1).GetChild(i).GetComponent<ParticleSystem>());
        // }

        // foreach(ParticleSystem p in flashParticles.GetComponentsInChildren<ParticleSystem>())
        // {
        //     secondaryParticles.Add(p);
        // }
    }

    // public void turnLeft()
    // {
    //     int dir = 1;
    //     // int dir = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
    //     // float amount = Mathf.Abs((Input.GetAxis("Horizontal")));

    //     // Debug.Log("dir " + dir);
    //     // Debug.Log("amount " + amount);

    //     Steer(1, amount);
    // }

    // public void clickDown()
    // {
    //     left = true;
    // }
    // public void clickUp()
    // {
    //     left = false;

    // }

    // public void clickrDown()
    // {
    //     right = true;
    // }
    // public void clickrUp() { right = false; }

    //  public float pointer_x ;

    float chiglel;

  

    void Update()
    {

        // float direction;
        // if (Input.touchCount > 0)
        // {

        //     Touch getTouch =    Input.GetTouch(0);

        //     Vector3 t = Camera.main.ScreenToWorldPoint(getTouch.position);

        //     Debug.Log(t);

        // if (Input.GetTouch(0).position.x < Screen.width / 2)
        // {
        //     direction = -1f;
        // }

        // else if (Input.GetTouch(0).position.x > Screen.width / 2)
        // {
        //     direction = 1f;
        // }
        // }


        // x = direction * speed * Time.deltaTime;

        // Vector2 newPosition = rb.position + new Vector2(x, upSpeed * Time.deltaTime);

        // newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        // rb.MovePosition(newPosition);

        // rb.transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);


        // if(Input.GetMouseButton(0)) {
        //     float pointer_x = Input.GetAxis("Mouse X");
        // Debug.Log(pointer_x);
        // }


        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     float time = Time.timeScale == 1 ? .2f : 1;
        //     Time.timeScale = time;
        // }

        //Follow Collider
        transform.position = sphere.transform.position - new Vector3(0, 0.4f, 0);

        //Accelerate 
        // ============================
        // Mouse 1 дарахад speed = 30 болно
        // ==================================



        speed = acceleration;


        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                //Move Player Left
                // baruun = turntoright * steering * Time.deltaTime;
                // if (chiglel < 1) chiglel = turntoleft * steering * Time.deltaTime;
                chiglel = Mathf.Lerp(0, 1, steering);
            }
            else if (Input.mousePosition.x < Screen.width / 2)
            {
                //Move Player Right
                chiglel = Mathf.Lerp(0, -1, steering);
            }
        }
        else
        {
            // chiglel=0; baruun = 0;
        }


        // Debug.Log("chiglel up" + chiglel);


        //Steer
        if (chiglel != 0)
        {
            int dir = chiglel > 0 ? 1 : -1;

            // Debug.Log(dir);
            float amount = Mathf.Abs((chiglel));
            Steer(dir, amount);
        }



        //Drift
        if (Input.GetButtonDown("Jump") && !drifting && chiglel != 0)
        {
            drifting = true;
            driftDirection = chiglel > 0 ? 1 : -1;

            // foreach (ParticleSystem p in primaryParticles)
            // {
            //     p.startColor = Color.clear;
            //     p.Play();
            // }

            kartModel.parent.DOComplete();
            kartModel.parent.DOPunchPosition(transform.up * .2f, .3f, 5, 1);
        }

        if (drifting)
        {
            float control = (driftDirection == 1) ? ExtensionMethods.Remap(chiglel, -1, 1, 0, 2) : ExtensionMethods.Remap(chiglel, -1, 1, 2, 0);
            float powerControl = (driftDirection == 1) ? ExtensionMethods.Remap(chiglel, -1, 1, .2f, 1) : ExtensionMethods.Remap(chiglel, -1, 1, 1, .2f);
            Steer(driftDirection, control);
            // driftPower += powerControl;

            // ColorDrift();
        }

        // if (Input.GetMouseButtonUp(0) && drifting)
        // { 
        //     Boost();
        // }

        currentSpeed = Mathf.SmoothStep(currentSpeed, speed, Time.deltaTime * 12f); speed = 0f;
        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f); rotate = 0f;

        // Animations    
        //a) Kart
        if (!drifting)
        {
            kartModel.localEulerAngles = Vector3.Lerp(kartModel.localEulerAngles, new Vector3(0, 90 + (chiglel * 15), kartModel.localEulerAngles.z), .2f);
        }
        else
        {
            float control = (driftDirection == 1) ? ExtensionMethods.Remap(chiglel, -1, 1, .5f, 2) : ExtensionMethods.Remap(chiglel, -1, 1, 2, .5f);
            kartModel.parent.localRotation = Quaternion.Euler(0, Mathf.LerpAngle(kartModel.parent.localEulerAngles.y, (control * 15) * driftDirection, .2f), 0);
        }

        //b) Wheels / dugui ergene/
        frontWheels.localEulerAngles = new Vector3(0, (chiglel * 15), frontWheels.localEulerAngles.z);
        frontWheels.localEulerAngles += new Vector3(0, 0, sphere.velocity.magnitude / 2);
        backWheels.localEulerAngles += new Vector3(0, 0, sphere.velocity.magnitude / 2);

        //c) Steering Wheel / Наад рулээ мушги
        steeringWheel.localEulerAngles = new Vector3(-25, 90, ((chiglel * 45)));
        // actionToMaterial();
        chiglel = 0;
    }

    private void FixedUpdate()
    {
        //Forward Acceleration
        if (!drifting)
            sphere.AddForce(-kartModel.transform.right * currentSpeed, ForceMode.Acceleration);
        else
            sphere.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);

        //Gravity
        sphere.AddForce(Vector3.down * gravity, ForceMode.Acceleration);

        //Steering
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);

        // RaycastHit hitOn;
        // RaycastHit hitNear;

        // Physics.Raycast(transform.position + (transform.up * .1f), Vector3.down, out hitOn, 1.1f, layerMask);
        // Physics.Raycast(transform.position + (transform.up * .1f), Vector3.down, out hitNear, 2.0f, layerMask);

        // // //Normal Rotation
        // kartNormal.up = Vector3.Lerp(kartNormal.up, hitNear.normal, Time.deltaTime * 8.0f);
        // kartNormal.Rotate(0, transform.eulerAngles.y, 0);
    }

    // public void Boost()
    // {
    //     drifting = false;

    //     if (driftMode > 0)
    //     {
    //         DOVirtual.Float(currentSpeed * 3, currentSpeed, .3f * driftMode, Speed);
    //         DOVirtual.Float(0, 1, .5f, ChromaticAmount).OnComplete(() => DOVirtual.Float(1, 0, .5f, ChromaticAmount));
    // kartModel.Find("Tube001").GetComponentInChildren<ParticleSystem>().Play();
    // kartModel.Find("Tube002").GetComponentInChildren<ParticleSystem>().Play();
    // }

    // driftPower = 0;
    // driftMode = 0;
    // first = false; second = false; third = false;

    // foreach (ParticleSystem p in primaryParticles)
    // {
    //     p.startColor = Color.clear;
    //     p.Stop();
    // }

    //     kartModel.parent.DOLocalRotate(Vector3.zero, .5f).SetEase(Ease.OutBack);
    // }

    public void Steer(int direction, float amount)
    {
        rotate = (steering * direction) * amount;
    }

    // public void ColorDrift()
    // {
    //     if(!first)
    //         c = Color.clear;

    //     if (driftPower > 50 && driftPower < 100-1 && !first)
    //     {
    //         first = true;
    //         c = turboColors[0];
    //         driftMode = 1;

    //         // PlayFlashParticle(c);
    //     }

    //     if (driftPower > 100 && driftPower < 150- 1 && !second)
    //     {
    //         second = true;
    //         c = turboColors[1];
    //         driftMode = 2;

    //         // PlayFlashParticle(c);
    //     }

    //     if (driftPower > 150 && !third)
    //     {
    //         third = true;
    //         c = turboColors[2];
    //         driftMode = 3;

    //         // PlayFlashParticle(c);
    //     }

    // foreach (ParticleSystem p in primaryParticles)
    // {
    //     var pmain = p.main;
    //     pmain.startColor = c;
    // }

    // foreach(ParticleSystem p in secondaryParticles)
    // {
    //     var pmain = p.main;
    //     pmain.startColor = c;
    // }
    // }


    // void PlayFlashParticle(Color c)
    // {
    //     GameObject.Find("CM vcam1").GetComponent<CinemachineImpulseSource>().GenerateImpulse();

    //     // foreach (ParticleSystem p in secondaryParticles)
    //     // {
    //     //     var pmain = p.main;
    //     //     pmain.startColor = c;
    //     //     p.Play();
    //     // }
    // }

    private void Speed(float x)
    {
        currentSpeed = x;
    }

    // void ChromaticAmount(float x)
    // {
    //     postProfile.GetSetting<ChromaticAberration>().intensity.value = x;
    // }

    // private void OnDrawGizmos()
    // {
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position + transform.up, transform.position - (transform.up * 2));
    // }
}
