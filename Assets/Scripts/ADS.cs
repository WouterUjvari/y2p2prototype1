using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS : MonoBehaviour {

    public Animator anim;
    public GameObject origin;
    public Transform originPosition;
    public GameObject ads;
    public Transform adsPosition;
    public GameObject parent;

    public Camera mainCamera;
    public Camera gunCamera;

    public ReloadGun myReload;



    public bool canADS;
    public bool inADS;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        myReload = GetComponent<ReloadGun>();
        // originPosition = origin.transform;
        // adsPosition = ads.transform;
    }

    void Update()
    {
        originPosition = origin.transform;
        adsPosition = ads.transform;
        if (canADS)
        {
            if (Input.GetButton("Fire2"))
            {
                inADS = true;
                parent.transform.position = Vector3.Lerp(parent.transform.position, adsPosition.position, 10 * Time.deltaTime);
                mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 50, 10 * Time.deltaTime);
                gunCamera.fieldOfView = Mathf.Lerp(gunCamera.fieldOfView, 60, 10 * Time.deltaTime);
                anim.SetLayerWeight(1, 0.01f);
            }
            else
            {
                inADS = false;
                parent.transform.position = Vector3.Lerp(parent.transform.position, originPosition.position, 7 * Time.deltaTime);
                mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 90, 10 * Time.deltaTime);
                gunCamera.fieldOfView = Mathf.Lerp(gunCamera.fieldOfView, 70, 10 * Time.deltaTime);
                anim.SetLayerWeight(1, 0.75f);
            }
        }  
    }
}
