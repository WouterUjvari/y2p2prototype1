using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    public Vector3 myTarget;
    public Transform myDistance;
    public static bool debugMode = false;

    public FireArm myfirearm;

    public Material skyboxMat;

    public AudioSource source1;
    public AudioSource source2;
    public AudioSource source3;



    void Update()
    {
        skyboxMat.SetFloat("_Rotation", Time.time);

        if (debugMode)
        {
            Debug.DrawRay(gameObject.transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            Time.timeScale = 0.5f;
            source1.pitch = 0.30f;
            source2.pitch = 0.6f;
            source3.pitch = 1;


        }else
        {
            source1.pitch = 0.65f;
            source2.pitch = 1.21f;
            source3.pitch = 2.19f;
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
