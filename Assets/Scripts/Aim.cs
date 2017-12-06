using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    public Vector3 myTarget;
    public Transform myDistance;
    public static bool debugMode = false;

    public Material skyboxMat;

    void Update()
    {
        skyboxMat.SetFloat("_Rotation", Time.time);

        if (debugMode)
        {
            Debug.DrawRay(gameObject.transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            Time.timeScale = 0.5f;
            
        }

        if (Input.GetKeyDown("`"))
        {
            debugMode = !debugMode;
            Time.timeScale = 1f;
            
        }
        

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * 1000, out hit))
        {           
            if(hit.transform.gameObject.tag != "Projectile")
            {
                myTarget = hit.point;
            }
           

        }
        else
        {
            myTarget = myDistance.position;

        }         
    }
}
