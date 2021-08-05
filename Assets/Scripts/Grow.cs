using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    // public int Critital;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Trail")
        {
            GrowManager.Instance.touchedGrow = true;
            Destroy(this.gameObject);
        }        
    }
}
