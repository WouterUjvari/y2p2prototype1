using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    public Vector3 myTarget;
    public Transform myDistance;

    void Update()
    {
        Debug.DrawRay(gameObject.transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * 1000, out hit))
        {           
                myTarget = hit.point;                      
        }
        else
        {
            myTarget = myDistance.position;
        }         
    }
}
